using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Office.Interop.Excel;

namespace DATCOM;

public sealed class DATCOM_Manager
{

    
    public DATCOM_Model? CurrentModel { get; private set; }

    public IList<DATCOM_Model> MyModels { get; } = new List<DATCOM_Model>();

    public DATCOM_File? CurrentFile { get; private set; }

    public IList<DATCOM_File> MyFiles { get; } = new List<DATCOM_File>();

    public IList<DATCOM_File> FileCollection { get; } = new List<DATCOM_File>();

    public string DATCOM_Command { get; set; } = string.Empty;

    public Application? TheExcelApp { get; set; }

    public DATCOM_Manager(string path)
    {
        MyModels = new List<DATCOM_Model>();
        setDatcomFullPath(path);
    }

    

    

    public void SetCurrentModel(DATCOM_Model model)
    {
        CurrentModel = model ?? throw new ArgumentNullException(nameof(model));
        if (!MyModels.Contains(model))
        {
            MyModels.Add(model);
        }
    }

    public void SetCurrentFile(DATCOM_File file)
    {
        CurrentFile = file ?? throw new ArgumentNullException(nameof(file));
        if (!MyFiles.Contains(file))
        {
            MyFiles.Add(file);
        }
    }

    public string setDatcomFullPath(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException("Path cannot be empty.", nameof(path));
        }
        DATCOM_Command = path + "DATCOM.exe";
        return DATCOM_Command;
    }

    public string AddInputFile(string filePath, string fileName)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("File path cannot be empty.", nameof(filePath));
        }

        DATCOM_File newInputFile = new DATCOM_File();

        newInputFile.FileName = fileName;
        newInputFile.InputPath = filePath;

        string fullPath = Path.Combine(filePath, fileName);

        if (!FileCollection.Contains(newInputFile))
        {
            FileCollection.Add(newInputFile);
        }

        return fullPath;
    }

    public bool RunDATCOM(double startAltitude, double startMachNumber)
    {
        if (CurrentFile is null || TheExcelApp is null)
        {
            return false;
        }

        CurrentFile.SetFlightConditions(startAltitude, startMachNumber);

        try
        {
            foreach (var _ in FileCollection)
            {
                var sourceFile = Path.Combine(CurrentFile.InputPath, "for005.dat");
                if (File.Exists(sourceFile))
                {
                    var backupPath = Path.Combine(CurrentFile.InputPath, $"for005.dat.old{Guid.NewGuid():N}");
                    File.Move(sourceFile, backupPath, overwrite: true);
                }

                CurrentFile.ExecuteDATCOM(sourceFile);
            }

            var workbookPath = Path.Combine(CurrentFile.InputPath, "for042.csv");
            if (!File.Exists(workbookPath))
            {
                return false;
            }

            var workbook = TheExcelApp.Workbooks.Open(workbookPath);
#pragma warning disable CA1416
            var outputWorksheet = (Worksheet)TheExcelApp.ActiveSheet;
#pragma warning restore CA1416
            _ = outputWorksheet;
            workbook.Close(false);

            return true;
        }
        catch
        {
            return false;
        }
    }


    public void readModelsFromFiles(DATCOM_File file)
    {
        try
        {
            file.ReadInputDeck(file.InputPath);
            foreach (var model in file.DATCOM_Models)
            {
                if (!MyModels.Contains(model))
                {
                    MyModels.Add(model);
                }
            }

        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("Failed to read models from file.", ex);
        }
    }

    public DATCOM_Model createModel()
    {
        var model = new DATCOM_Model();
        MyModels.Add(model);
        return model;
    }

}

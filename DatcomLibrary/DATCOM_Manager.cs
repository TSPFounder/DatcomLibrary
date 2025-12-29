using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Office.Interop.Excel;

namespace DATCOM;

public sealed class DATCOM_Manager
{
    public DATCOM_Model? CurrentModel { get; private set; }

    public IList<DATCOM_Model> MyModels { get; } = new List<DATCOM_Model>();

    public DATCOM_File? CurrentFile { get; private set; }

    public IList<DATCOM_File> MyFiles { get; } = new List<DATCOM_File>();

    public IList<string> FileCollection { get; } = new List<string>();

    public string DATCOM_Command { get; set; } = string.Empty;

    public Application? TheExcelApp { get; set; }

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

    public void AddFileReference(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("File path cannot be empty.", nameof(filePath));
        }

        if (!FileCollection.Contains(filePath))
        {
            FileCollection.Add(filePath);
        }
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

                CurrentFile.ExecuteDATCOM();
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
}

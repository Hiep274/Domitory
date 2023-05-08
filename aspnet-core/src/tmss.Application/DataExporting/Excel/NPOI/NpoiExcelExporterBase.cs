using Abp.AspNetZeroCore.Net;
using Abp.Collections.Extensions;
using Abp.Dependency;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using tmss.Dto;
using tmss.Storage;

namespace tmss.DataExporting.Excel.NPOI
{
    public abstract class NpoiExcelExporterBase : tmssServiceBase, ITransientDependency
    {
        private readonly ITempFileCacheManager _tempFileCacheManager;

        protected NpoiExcelExporterBase(ITempFileCacheManager tempFileCacheManager)
        {
            _tempFileCacheManager = tempFileCacheManager;
        }

        protected FileDto CreateExcelPackage(string fileName, Action<XSSFWorkbook> creator)
        {
            var file = new FileDto(fileName, MimeTypeNames.ApplicationVndOpenxmlformatsOfficedocumentSpreadsheetmlSheet);
            var workbook = new XSSFWorkbook();

            creator(workbook);

            Save(workbook, file);

            return file;
        }

        protected void AddHeader(ISheet sheet, params string[] headerTexts )
        {
            if (headerTexts.IsNullOrEmpty())
            {
                return;
            }

             sheet.CreateRow(0);

            for (var i = 0; i < headerTexts.Length; i++)
            {
                AddHeader(sheet, i, headerTexts[i]);
            }
        }
        protected void AddHeaderStartRowIndex(ISheet sheet, int index, params string[] headerTexts)
        {
            if (headerTexts.IsNullOrEmpty())
            {
                return;
            }
            sheet.CreateRow(index);

            for (var i = 0; i < headerTexts.Length; i++)
            {
                AddHeaderStartRowIndex(sheet, i,index, headerTexts[i]);
            }
        }
        protected void AddHeaderStartRowIndex(ISheet sheet, int columnIndex,int index, string headerText)
        {
            var cell = sheet.GetRow(index).CreateCell(columnIndex);
            cell.SetCellValue(headerText);
            var cellStyle = sheet.Workbook.CreateCellStyle();
            var font = sheet.Workbook.CreateFont();
            font.FontHeightInPoints = 12;
            font.IsBold = true;
            cellStyle.SetFont(font);
            cell.CellStyle = cellStyle;
        }
        protected void AddHeader(ISheet sheet, int columnIndex, string headerText)
        {
            var cell = sheet.GetRow(0).CreateCell(columnIndex);
            cell.SetCellValue(headerText);
            var cellStyle = sheet.Workbook.CreateCellStyle();
            var font = sheet.Workbook.CreateFont();
            font.FontHeightInPoints = 12;
            font.IsBold = true;
            cellStyle.SetFont(font);
            cell.CellStyle = cellStyle;
        }
        protected void AddHeaderAssigmentCustomer(ISheet sheet, string v, int columnIndex, string headerText)
        {
            var cell = sheet.GetRow(4).CreateCell(columnIndex);
            cell.SetCellValue(headerText);
            var cellStyle = sheet.Workbook.CreateCellStyle();
            var font = sheet.Workbook.CreateFont();
            font.FontHeightInPoints = 12;
            font.IsBold = true;
            cellStyle.SetFont(font);
            cell.CellStyle = cellStyle;
        }

        protected void AddObjects<T>(ISheet sheet, int startRowIndex, IList<T> items, params Func<T, object>[] propertySelectors)
        {
            if (items.IsNullOrEmpty() || propertySelectors.IsNullOrEmpty())
            {
                return;
            }

            for (var i = startRowIndex; i <= (items.Count + startRowIndex -1); i++)
            {
                var row = sheet.CreateRow(i);

                for (var j = 0; j < propertySelectors.Length; j++)
                {
                    var cell = row.CreateCell(j);
                    var value = propertySelectors[j](items[i- startRowIndex]);
                    var style = value?.GetType();
                    var name = style?.Name;
                    if (value != null && name == "DateTime")
                    {
                        cell.SetCellValue((DateTime)value);
                    }
                    else
                        cell.SetCellValue(value?.ToString());
                }
            }
        }

        protected void Save(XSSFWorkbook excelPackage, FileDto file)
        {
            using (var stream = new MemoryStream())
            {
                excelPackage.Write(stream);
                _tempFileCacheManager.SetFile(file.FileToken, stream.ToArray());
            }
        }

        protected void SetCellDataFormat(ICell cell, string dataFormat)
        {
            if (cell == null)
            {
                return;
            }

            var dateStyle = cell.Sheet.Workbook.CreateCellStyle();
            var format = cell.Sheet.Workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat(dataFormat);
            cell.CellStyle = dateStyle;
            if (DateTime.TryParse(cell.DateCellValue.ToString(), out var datetime))
            {
                cell.SetCellValue(datetime);
            }
        }

        protected FileDto CreateExcelPackageAndSaveToFoler(string fileName, Action<XSSFWorkbook> creator)
        {
            var file = new FileDto(fileName, MimeTypeNames.ApplicationVndOpenxmlformatsOfficedocumentSpreadsheetmlSheet);
            var workbook = new XSSFWorkbook();

            creator(workbook);

            var folderName = Path.Combine("wwwroot", "InvalidImportFile");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            string path = Path.Combine(pathToSave, file.FileName);

            using (var stream = new MemoryStream())
            {
                workbook.Write(stream);
                FileStream xfile = new FileStream(path, FileMode.Create, FileAccess.Write);
                workbook.Write(xfile);
                xfile.Close();
                _tempFileCacheManager.SetFile(file.FileToken, stream.ToArray());
            }

            return file;
        }
    }
}
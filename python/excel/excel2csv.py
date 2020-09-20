# coding: utf-8
import sys
import os
import csv

import openpyxl as px

def main():
    args = sys.argv

    if len(args) < 2:
        print ('USAGE : excel2csv -e EXCELFILE')
        sys.exit()

    for i in range(len(args)):
        if args[i] == '-e':
            excel_file = args[i+1]

    exfilepath = os.path.abspath(excel_file)

    if os.path.exists(exfilepath) == False:
        print ('[ERROR] EXCEL FILE: ', excel_file, ' is not found')
        sys.exit()

    print ('EXCELFILE : ', exfilepath)

    convert_book_to_csvs(exfilepath)

    print ('FINISHED')

def convert_book_to_csvs(exfilepath):
    workbook = px.load_workbook(exfilepath, read_only=True, keep_vba=False)
    savedir = os.path.dirname(exfilepath)

    for sheetname in workbook.sheetnames:
        worksheet = workbook[sheetname]

        if not worksheet.max_row - 1:
            continue

        csv_filepath = os.path.join(savedir, str(sheetname) + '.csv')
        convert_sheet_to_csv(worksheet, csv_filepath)
        print ('CSVFILE : ', csv_filepath)

def convert_sheet_to_csv(worksheet, save_filepath):
    rows = enumerate_read_sheet_value_table(worksheet)
    write_csv(rows, save_filepath, 'utf-8', ',')

def contains_sheet(workbook, sheetname):
    for sh in workbook.sheetnames:
        if sh == sheet:
            return True
    return False

def convert_csvs_to_book(excel_filepath, csv_filepaths):
    workbook = px.load_workbook(excel_filepath)

    for csv_filepath in csv_filepaths:
        [sheetname, ext] = os.path.splitext(csv_filepath)

        if contains_sheet(workbook, sheetname):
            worksheet = workbook[sheetname]
            clear_sheet(worksheet)
        else:
            worksheet = workbook.create_sheet(title=sheetname)

        with open(csv_filepath, encoding='utf-8') as fp:
            reader = csv.reader(fp, delimiter=',')
            for row in reader:
                worksheet.append(row)

    workbook.save(excel_filepath)

def clear_sheet(worksheet):
    for row in worksheet.iter_rows():
        for cell in row:
            cell.value = None

def enumerate_read_sheet_value_table(worksheet):
    for cols in worksheet.rows:
        yield [str(col.value or '') for col in cols]

def read_sheet_value_table(worksheet):
    return [row for row in enumerate_read_sheet_value_table(worksheet)]

def enumerate_read_csv(filepath, encoding, delimiter):
    with open(filepath, encoding=encoding) as fp:
        reader = csv.reader(fp, delimiter=delimiter)
        for row in reader:
            yield row

def read_csv(filepath, encoding, delimiter):
    return [row for row in enumerate_read_csv(filepaath, encoding, delimiter)]

def write_csv(rows, filepath, encoding, delimiter):
    with open(filepath, 'w', newline='', encoding=encoding) as fp:
        writer = csv.writer(fp, lineterminator='\n')
        for row in rows:
            writer.writerow(row)

if __name__ == '__main__':
    main()
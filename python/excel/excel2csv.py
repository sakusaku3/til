# coding: utf-8

import sys
import os
import csv

import openpyxl as px

def main():

    args = sys.argv
    excelFile = ''
    csvFile = ''
    sheetName = ''

    if len(args) < 2:
        print ('USAGE : excel2csv -excel EXCELFILE -csv CSVFILE -sheetName SHEETNAME')
        sys.exit()

    for i in range(len(args)):
        if args[i] == '-excel':
            excelFile = args[i+1]
        if args[i] == '-csv':
            csvFile = args[i+1]
        if args[i] == '-sheetName':
            sheetName = args[i+1]

    exfilepath = os.path.abspath(excelFile)

    if os.path.exists(exfilepath) == False:
        print ('!!!ERROR!!! EXCEL FILE', excelFile, ' is not found')
        sys.exit()

    workBook = px.load_workbook(exfilepath, read_only=True, keep_vba=False)

    flg = 0
    for sn in workBook.sheetnames:
        if sn == sheetName:
            flg = 1
            break

    if flg == 0:
        print ('!!!ERROR!!! SHEET NAME', sheetName , ' is not found')
        sys.exit()

    if csvFile == '':
        csvFile = exfilepath + '.' + sheetName + '.csv'
    else:
        csvFile = os.path.dirname(exfilepath) + '/' + csFilef

    print ('EXCELFILE : ', exfilepath)
    print ('SHEETNAME : ', sheetName)
    print ('CSVFILE : ', csvFile)

    workSheet = workBook[sheetName]

    with open(csvFile, 'w', encoding='utf-8') as fp:
        writer = csv.writer(fp)
        for cols in workSheet.rows:
            writer.writerow([str(col.value or '') for col in cols])

    print ('FINISHED')

if __name__ == '__main__':　
    main()
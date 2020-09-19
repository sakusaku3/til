# coding: utf-8

import sys
import os
import csv

import openpyxl as px

def main():

    args = sys.argv
    excelFilepath = ''
    csvName = ''
    sheetName = ''

    if len(args) < 2:
        print ('USAGE : excel2csv -e EXCELFILE -c CSVFILENAME -s SHEETNAME')
        sys.exit()

    for i in range(len(args)):
        if args[i] == '-e':
            excelFile = args[i+1]
        if args[i] == '-c':
            csvName = args[i+1]
        if args[i] == '-s':
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
        print ('!!!ERROR!!! SHEET NAME', sheetName, ' is not found')
        sys.exit()
    
    outFileName = sheetName if csvName == '' else csvName
    saveDir = os.path.dirname(exfilepath)
    csvFilepath = os.path.join(saveDir, outFileName + '.csv')

    print ('EXCELFILE : ', exfilepath)
    print ('SHEETNAME : ', sheetName)
    print ('CSVFILE : ', csvFilepath)

    workSheet = workBook[sheetName]

    with open(csvFilepath, 'w', newline='', encoding='utf-8') as fp:
        writer = csv.writer(fp, lineterminator='\n')
        for cols in workSheet.rows:
            writer.writerow([str(col.value or '') for col in cols])

    print ('FINISHED')

if __name__ == '__main__':
    main()
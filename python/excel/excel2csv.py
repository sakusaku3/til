# coding: utf-8

import sys
import os
import csv

import openpyxl as px

def main():

    args = sys.argv
    exf = ''
    csvf = ''
    sheet = ''

    if len(args) < 2:
        print ('USAGE : excel2csv -excel EXCELFILE -csv CSVFILE -sheet SHEETNAME')
        sys.exit()

    for i in range(len(args)):
        if args[i] == '-excel':
            exf = args[i+1]
        if args[i] == '-csv':
            csvf = args[i+1]
        if args[i] == '-sheet':
            sheet = args[i+1]

    exfilepath = os.path.abspath(exf)

    if os.path.exists(exfilepath) == False:
        print ('!!!ERROR!!! EXCEL FILE', exf , ' is not found')
        sys.exit()

    bk = px.load_workbook(exfilepath, read_only=True, keep_vba=False)

    flg = 0
    for sh in bk.sheetnames:
        if sh == sheet:
            flg = 1
            break

    if flg == 0:
        print ('!!!ERROR!!! SHEET NAME', sheet , ' is not found')
        sys.exit()

    if csvf == '':
        csvf = exfilepath + '.' + sheet + '.csv'
    else:
        csvf = os.path.dirname(exfilepath) + '/' + csvf

    print ('EXCELFILE : ',exfilepath)
    print ('SHEETNAME : ',sheet)
    print ('CSVFILE : ',csvf)

    ws = bk[sheet]

    with open(csvf, 'w', encoding='utf-8') as fp:
        writer = csv.writer(fp)
        for cols in ws.rows:
            writer.writerow([str(col.value or '') for col in cols])

    print ('FINISHED')

if __name__ == '__main__':　
    main()
import os
import glob
import argparse
from xml.etree import ElementTree

def main():
    parser = argparse.ArgumentParser(description='.NET projectファイルの解析')

    parser.add_argument('arg1', help='ディレクトリを指定')

    args = parser.parse_args()

    if not os.path.exists(args.arg1):
        print(f'[ERROR] directory not exists {args.arg1}')
    
    for filepath in glob.glob(f'{args.arg1}**/*.csproj', recursive=True):
        readxml_core(filepath)

    print('FINISHED')

def readxml_core(filepath):
    filename, ext = os.path.splitext(os.path.basename(filepath))

    tree = ElementTree.parse(filepath)
    root = tree.getroot()

    for child in getReferenceNetFramework(root):
        package_tuple = (filename, child)
        print(package_tuple)

def getReferenceNetCore(xml_tree_root):
    for child in xml_tree_root.iter('ProjectReference'):
        replaced = child.attrib['Include'].replace('\\', '/')
        reference, reference_ext = os.path.splitext(os.path.basename(replaced))
        yield reference 

    for child in xml_tree_root.iter('PackageReference'):
        package = f"{child.attrib['Include']}({child.attrib['Version']})"
        yield package

def getReferenceNetFramework(xml_tree_root):
    ns = 'http://schemas.microsoft.com/developer/msbuild/2003'

    for child in xml_tree_root.iter(f'{{{ns}}}ProjectReference'):
        replaced = child.attrib['Include'].replace('\\', '/')
        reference, reference_ext = os.path.splitext(os.path.basename(replaced))
        yield reference 

    for child in xml_tree_root.iter(f'{{{ns}}}PackageReference'):
        version = child.find(f'{{{ns}}}Version').text
        package = f"{child.attrib['Include']}({version})"
        yield package

if __name__ == '__main__':
    main()

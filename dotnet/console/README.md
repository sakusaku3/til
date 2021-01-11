# コンソール

## System.CommandLine

### やっちゃだめ
- サブコマンドの引数名に"""input""", """output"""使っちゃいけない
- 使うとargsのパース時に値が入らず, nullのまま
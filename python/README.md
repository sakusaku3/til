# python

## DockerでPython開発環境構築
- https://ittech-nsnl.hatenablog.com/entry/2019/11/12/233136
- https://ittech-nsnl.hatenablog.com/entry/2019/11/20/233219 

## 環境構築
- Anaconda入れた
- PATH通した
```bash:.bash_profile
ANA_PATH=/cygdrive/c/Anaconda3
export PATH=\$ANA_PATH:\$ANA_PATH/Library/bin:\$ANA_PATH/Scripts:$PATH
```

## Anaconda3コマンドまとめ

### よく使う
- 現在の仮想環境情報
```bash
conda info
```

- インストールされているパッケージ一覧表示
```bash
conda list
```

### 参考
- [Anaconda3 コマンドまとめ](https://qiita.com/WestRiver/items/cce9c99076d59abd3f69)

## Anacondaトラブルシューティング
### mklのロードに失敗
- 下記のように出たとき
```bash
Intel MKL FATAL ERROR: Cannot load mkl_intel_thread.dll.
```

- [ここ](https://nu-pan.hatenablog.com/entry/2018/10/12/232502)を参考にしてみる
- mklをダウングレード
```bash
conda install mkl=2018.0.2
```

## globモジュール
- 引数に指定されたパターンにマッチするファイルパスを取得することが出来る
- 特定のディレクトリに存在するファイルに処理を加えたい場合とか

### 参考
- [globの使い方](https://qiita.com/HirosuguTakeshita/items/0e0850362c7eb3b10ea1)

## その他
- [ファイル/ディレクトリ操作](https://qiita.com/supersaiakujin/items/12451cd2b8315fe7d054)
- [python命名規則](https://qiita.com/naomi7325/items/4eb1d2a40277361e898b)
- [csv読み書き](https://techacademy.jp/magazine/15638)
- [docstring](https://qiita.com/simonritchie/items/49e0813508cad4876b5a)
- [argparse](https://qiita.com/kzkadc/items/e4fc7bc9c003de1eb6d0)


```bash
apt-get update
apt-get install libgraphviz-dev
apt-get install graphviz
pip install graphviz
pip install pygraphviz
pip install networkx
```

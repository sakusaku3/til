# python

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


## 参考
- [ファイル/ディレクトリ操作](https://qiita.com/supersaiakujin/items/12451cd2b8315fe7d054)
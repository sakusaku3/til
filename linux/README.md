# Linux


## 環境変数
- プログラムの挙動を調整するためのパラメータの1種である
- 様々なプログラムであたかも同じパラメータを共有しているように振る舞うため、各種プログラムの実行環境を司る設定情報として使われる

### 参考
- https://qiita.com/angel_p_57/items/480e3fd4552e52199835
- https://qiita.com/angel_p_57/items/03582181e9f7a69f8168
- https://qiita.com/chihiro/items/bb687903ee284766e879

## 環境変数読み込み順番
1. /etc/profile
1. ~/.bash_profile
    なければ
    1. ~/.bash_login
    1. ~/.profile
1. ~/.bashrc
1. /etc/bashrc
1. bash実行

- [読み込み順番](https://qiita.com/yunzeroin/items/480a3a677f78a57ac52f)

## /etc/profile
- sh系でログインしたときに読み込まれる設定ファイル
- sh系(sh, bash, ksh, zsh)
- https://wa3.i-3-i.info/word11795.html


## プロキシ設定
- https://qiita.com/sachioksg/items/289e40d69382b1d09811
- https://kaede.jp/2020/04/22225145/

### no_proxyって?
- 一番簡単な方法は、以下のように環境変数でプロキシ設定をする方法

```bash
export http_proxy=http://proxy.example.com:8080/
export https_proxy=http://proxy.example.com:8080/
```

- これだとそのシェルから実行されるプロブラムでのHTTP(S)アクセスがすべてプロキシ経由となってしまう
- 検証環境内部で動いているサービスへのアクセスにもプロキシを使おうとしてしまう
- それを避けるために設定するのが```no_proxy```環境変数
- 以下のように設定する

```bash
export no_proxy=127.0.0.1,localhost,192.168.1.1
```

### 参考
- [no_proxy](https://sechiro.hatenablog.com/entry/2013/08/06/no_proxy_%E3%81%AB%E3%83%8D%E3%83%83%E3%83%88%E3%83%AF%E3%83%BC%E3%82%AF%E3%82%A2%E3%83%89%E3%83%AC%E3%82%B9%E3%81%A8%E3%81%8B%E3%83%AF%E3%82%A4%E3%83%AB%E3%83%89%E3%82%AB%E3%83%BC%E3%83%89%E3%82%92)
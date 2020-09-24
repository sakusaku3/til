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
# docker
## 全体像を把握する
- [いまさらだけどDockerに入門したので分かりやすくまとめてみた](https://qiita.com/gold-kou/items/44860fbda1a34a001fc1)


## Homeに導入する
- [windows 10 home で docker を導入するメモ](https://qiita.com/idani/items/fb7681d79eeb48c05144) → wsl2と競合しちゃうからだめ
- [Windows 10 Home で WSL 2 + Docker を使う](https://qiita.com/KoKeCross/items/a6365af2594a102a817b) → こっちでやったらできた


## コマンド
- Dockerイメージ削除```docker image rm [コンテナID]```


## 用語
### Docker Engine
Dockerを利用するための常駐プログラム

### コンテナ
アプリケーションの実行環境

### イメージ(Image)
Imageはコンテナの元、Imageからコンテナを起動する

### Tag
Imageのバージョンのこと
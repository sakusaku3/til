# docker
## コマンド

### docker-compose up
ymlで定義したサービスを開始または再起動する

### docker-compose run
一度だけなタスクを実行する

- サービス名の指定が必要

### docker-compose start
すでに作成済みのコンテナを再起動する


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


## Docker Desktop for WindowsのProxy設定
- 「docker deamon」「docker container」の二箇所設定が必要
- 「docker deamon」は```docker pull```や```docker build```などを実行するdeamonが参照するproxyの設定
- 「docker container」は```docker run```で起動された、docker container上で走るOSが使うproxyの設定

### docker deamonへの設定
- [ここ](https://qiita.com/wryun0suke/items/1f4bbd2977ae41ee7a36)参照

### docker containerへの設定
- config.jsonに追記して、docker clientの設定にproxyを加える
- windowsの場合、```config.json```は```%USERPROFILE%\.docker\config.json```に配置される

```json:%USERPROFILE%\.docker\config.json
{
 "credsStore":"desktop",
 "stackOrchestrator":"swarm",
 "proxies":
 {
   "default":
   {
     "httpProxy": "http://127.0.0.1:3001",
     "httpsProxy": "http://127.0.0.1:3001",
     "noProxy": "*.test.example.com,.example2.com"
   }
 }
}
```

### 参考
- https://qiita.com/2fbCvmiYKX/items/c6aab333364af25fd924


## Dockerにおけるボリュームのマウント
ホストのボリュームをマウントするには、とりあえずCompose使うのがいいんじゃない

- https://logicoffee.hatenablog.com/entry/2018/06/21/123025
- https://qiita.com/namutaka/items/f6a574f75f0997a1bb1d
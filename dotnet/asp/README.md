# ASP.NET Core


## 練習1
- [チュートリアル: ASP.NET Core で Web API を作成する](https://docs.microsoft.com/ja-jp/aspnet/core/tutorials/first-web-api?view=aspnetcore-5.0&tabs=visual-studio)


### DBコンテキストって?
- POCOをデータベースに接続する----橋渡しの役目を果たすのがコンテキスト・クラス
- [Entity Frameworkコード・ファーストでモデル開発](https://www.atmarkit.co.jp/fdotnet/aspnetmvc3/aspnetmvc3_03/aspnetmvc3_03_02.html)


### スキャフォールディング
- Scaffolding（スキャフォールディング）とは、データモデルとなる型を元に、いわゆるCRUD（Create/Read/Upadate/Delete)と呼ばれる追加、読込、変更、削除を行う画面とそのコードを自動で生成する機能のこと
- [ASP.NET 4.5の「Scaffolding（スキャフォールディング）」機能を試す（前編）](https://codezine.jp/article/detail/7491)

### トラブルシューティング
- Contorollersにスキャフォールディングされたhogeを新規追加の所でミスる
    - Microsoft.VisualStudio.Web.CodeGeneration.Designがインストールされているように見えるのに、インストールしてからやれと言われる
	- 一度消してから、再度Microsoft.VisualStudio.Web.CodeGeneration.Designをインストールし直す
	- 次に進んだ

- Webアプリを起動します の所でつまづいた、なにやったら起動するのかわかんなかった
    - F5でデバッグ開始すればよい
	- HttpsとHttpでポートが違うから注意←当たり前？初心者だからわがんね


## 練習2
https://docs.microsoft.com/ja-jp/aspnet/core/tutorials/web-api-javascript?view=aspnetcore-5.0


## 練習3
https://qiita.com/rawr/items/85abf5f646e20e3438a1




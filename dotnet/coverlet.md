# coverlet
- クロスプラットフォームな.NETのコードカバレッジツール
- 3つドライバーが提供されている
- https://github.com/coverlet-coverage/coverlet

|ドライバー|説明|ドキュメント|
|:---|:---|:---|
|coverlet.collector|VSTestへの統合用|[DOC](https://github.com/coverlet-coverage/coverlet/blob/master/Documentation/VSTestIntegration.md)|
|coverlet.msbuild|MSBuildへの統合用|[DOC](https://github.com/coverlet-coverage/coverlet/blob/master/Documentation/MSBuildIntegration.md)|
|coverlet.console|グローバルツール|[DOC](https://github.com/coverlet-coverage/coverlet/blob/master/Documentation/GlobalTool.md)|


## coverlet.collector
- VSTestへ統合するドライバー
- VSTest(Visual Studio Test Platform)はオープンソース化されていて、他でアダプタを作成できる
- coverlet.collectorはその、VSTestのアダプタとして作成されたもの
- a.k.a: also known as (別名, ~としても知られる)

### reference
- https://github.com/Microsoft/vstest
- https://www.infoq.com/jp/news/2017/01/visual-studio-test/

## coverlet.msbuild
- MSBuildへ統合するドライバー
- ```dotnet test```インフラに統合する
- このパッケージをテストプロジェクトに追加して使用する
- N.B. nota bene (注意せよ)

### 手順
1. テストプロジェクトに```coverlet.msbuild```のパッケージを追加する
```bash
dotnet add package coverlet.msbuild
```

2. テスト実行(```./results/```ディレクトリにopencoverのフォーマットで出力)
```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:CoverletOutput'./results/'
```

## reference
- https://docs.microsoft.com/ja-jp/dotnet/core/testing/unit-testing-code-coverage?tabs=linux


## ReportGenerator
OpenCoverとかからカバレッジレポートを生成する

- https://github.com/danielpalme/ReportGenerator


### 使用方法1 テストプロジェクトのpackageに追加する
packageに追加
```bash
dotnet add package ReportGenerator
```

packageに追加するとrestore時に下記フォルダへツールが展開される
```
(UserProfile)\.nuget\packages\reportgenerator\
```

使い方
```bash
dotnet (UserProfile)/.nuget/packages/reportgenerator/x.y.z/tools/netcoreapp3.0/ReportGenerator.dll -reports:(coverage.xml) -targetdir:(outdir)
```

### 使用方法2 .NET Coreツールをインストールする
.NET Coreツールのインストール方法は3つある
1. グローバルツール
1. カスタムの場所のグローバルツール(a.k.a tool-pathツール)
1. ローカルツールとして

とりあえずグローバルツールでインストール
```bash
dotnet tool install -g dotnet-reportgenerator-globaltool
```

使い方
```bash
reportGenerator -reports:(coverage.xml) -targetdir:(outdir)
```

### reference
- https://qiita.com/shikazuki/items/8a9ef6e95b02d55f4d3d
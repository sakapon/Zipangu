# Zipangu
[![license](https://img.shields.io/github/license/sakapon/Zipangu.svg)](LICENSE)
[![NuGet](https://img.shields.io/nuget/v/Zipangu.svg)](https://www.nuget.org/packages/Zipangu/)
[![NuGet](https://img.shields.io/nuget/dt/Zipangu.svg)](https://www.nuget.org/packages/Zipangu/)

A library for compatibility about Japan.  
日本で利用される機能を集めたライブラリです。

## Setup
Zipangu は NuGet Gallery に登録されています。  
Zipangu を利用するには、Visual Studio の [NuGet パッケージの管理] でインストールするか、  
あるいは [パッケージ マネージャー コンソール] で次のコマンドを実行します。

```
Install-Package Zipangu
```

[NuGet Gallery | Zipangu](https://www.nuget.org/packages/Zipangu/)

## Features
### 文字の変換
.NET Framework の Microsoft.VisualBasic.dll の [Strings.StrConv メソッド](https://docs.microsoft.com/dotnet/api/microsoft.visualbasic.strings.strconv)との互換性は完全ではありません。  
[仕様の詳細はこちら](docs/Char-Conversion)。
- ASCII 文字 → 全角 ASCII 文字
- 全角 ASCII 文字 → ASCII 文字
- ひらがな → カタカナ
- カタカナ → ひらがな
- 半角カタカナ → ひらがな
- 半角カタカナ → カタカナ

### 文字エンコーディング
各エンコーディングのインスタンスにアクセスするためのプロパティを提供します。
- Shift_JIS (932)
- ISO-2022-JP (50220)
- EUC-JP (51932)

## Usage
まず、`Zipangu` 名前空間の using ディレクティブを追加します。
```c#
using System;
using Zipangu;
```

### 文字の変換
各メソッドは拡張メソッドとして提供されています。
```c#
// べーとーゔぇん、「ぴあの・そなた」。
var result = "ﾍﾞｰﾄｰｳﾞｪﾝ､｢ﾋﾟｱﾉ･ｿﾅﾀ｣｡".HalfKatakanaToHiragana();
```

変換の種類を組み合わせるには、`Convert` メソッドを呼び出します。
```c#
// モモイロクローバーＺ
var result = "ももいろｸﾛｰﾊﾞｰZ".Convert(KanaConv.AllKanaToKatakana, AsciiConv.ToWide);
```

### 文字エンコーディング
`EncodingHelper` クラスの静的プロパティで各エンコーディングのインスタンスを取得できます。
```c#
// { 188, 172, 151, 144, 81 }
var result = EncodingHelper.ShiftJIS.GetBytes("ｼｬ乱Q");
```

## Target Frameworks
- .NET Standard 2.0
  - [.NET Core 2.0, UWP 10.0.16299 など](https://docs.microsoft.com/ja-jp/dotnet/standard/net-standard)
- .NET Framework 4.0

### Dependencies
- [System.Text.Encoding.CodePages](https://www.nuget.org/packages/System.Text.Encoding.CodePages/) (.NET Standard 2.0)

## Release Notes
- **v1.1.8** 変換される文字を追加。
- **v1.1.6** 文字エンコーディングのプロパティを追加。
- **v1.0.3** 初版リリース。
- **v1.0.1** β版リリース。

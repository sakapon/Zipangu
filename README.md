# Zipangu
[![license](https://img.shields.io/github/license/sakapon/Zipangu.svg)](LICENSE)
[![NuGet](https://img.shields.io/nuget/v/Zipangu.svg)](https://www.nuget.org/packages/Zipangu/)
[![NuGet](https://img.shields.io/nuget/dt/Zipangu.svg)](https://www.nuget.org/packages/Zipangu/)

A library for compatibility about Japan.  
日本における互換性のためのライブラリです。

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
詳細: [Char Conversion](docs/Char-Conversion)
- ASCII 文字 → 全角 ASCII 文字
- 全角 ASCII 文字 → ASCII 文字
- ひらがな → カタカナ
- カタカナ → ひらがな
- 半角カタカナ → ひらがな
- 半角カタカナ → カタカナ

## Usage
### 文字の変換
まず、Zipangu 名前空間の using ディレクティブを追加します。
```c#
using System;
using Zipangu;
```

各メソッドは拡張メソッドとして提供されています。
```c#
// べーとーゔぇん、「ぴあの・そなた」。
var result = "ﾍﾞｰﾄｰｳﾞｪﾝ､｢ﾋﾟｱﾉ･ｿﾅﾀ｣｡".HalfKatakanaToHiragana();
```

変換の種類を組み合わせるには、`Convert` メソッドを呼び出します。
```c#
// モーニング娘。＇１８
var result = "ﾓｰﾆﾝｸﾞ娘｡'18".Convert(KanaConv.HalfKatakanaToKatakana, AsciiConv.ToWide);
```

## Target Frameworks
- .NET Standard 2.0
- .NET Framework 4.0

## Release Notes
- **v1.0.3** 初版リリース。
- **v1.0.1** β版リリース。

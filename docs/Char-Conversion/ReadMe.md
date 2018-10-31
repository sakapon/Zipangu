# 文字の変換

## 変換の種類
- ASCII 文字 → 全角 ASCII 文字
- 全角 ASCII 文字 → ASCII 文字
- ひらがな → カタカナ
- カタカナ → ひらがな
- 半角カタカナ → ひらがな
- 半角カタカナ → カタカナ

## 仕様

### ASCII 文字
ASCII 文字の半角・全角を相互に変換します。
- AsciiToWide
- AsciiToNarrow

文字の種類
- ASCII 文字: 0020-007E
- 全角 ASCII 文字: 3000 (全角スペース) および FF01-FF5E

例
```c#
// Ｂ’ｚ
var result = "B'z".AsciiToWide();
```

### かな (全角)
ひらがな・カタカナを相互に変換します。
- HiraganaToKatakana
- KatakanaToHiragana

文字の種類
- ひらがな: `ぁ` ～ `ん` および `ゔゕゖゝゞ`
- カタカナ: `ァ` ～ `ン` および `ヴヵヶヽヾ`

`゛゜・ー` は共通です。

例
```c#
// ももいろくろーばーZ
var result = "ももいろクローバーZ".KatakanaToHiragana();
```

### 半角カタカナ
半角カタカナをひらがな・カタカナに変換します。
- HalfKatakanaToHiragana
- HalfKatakanaToKatakana

文字の種類
- 半角カタカナ: `ｦ` ～ `ﾝ` および `｡｢｣､･ﾞﾟ`

記号はそれぞれ `。「」、・゛゜` に変換されます。  
また、半角カタカナの濁音・半濁音 2 文字が、ひらがな・カタカナ 1 文字に変換されます。
- 濁点が付く文字
  - ひらがなに変換: `ｳｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾊﾋﾌﾍﾎ`
  - カタカナに変換: `ｦｳｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾊﾋﾌﾍﾎﾜ`
- 半濁点が付く文字
  - ひらがなに変換: `ﾊﾋﾌﾍﾎ`
  - カタカナに変換: `ﾊﾋﾌﾍﾎ`

例
```c#
// ももいろクローバーZ
var result = "ももいろｸﾛｰﾊﾞｰZ".HalfKatakanaToKatakana();
```

### References
- [文字の種類 (Unicode)](Unicode.md)
- [VisualBasic.Strings との互換性](VBStrings-Compatibility.md)

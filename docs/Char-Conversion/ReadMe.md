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
- ひらがな: `ぁ` ～ `ん` および `ゔゝゞ`
- カタカナ: `ァ` ～ `ン` および `ヴヽヾ`

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
- 濁点が付く文字: `ｳｶｷｸｹｺｻｼｽｾｿﾀﾁﾂﾃﾄﾊﾋﾌﾍﾎ`
- 半濁点が付く文字: `ﾊﾋﾌﾍﾎ`

例
```c#
// ももいろクローバーZ
var result = "ももいろｸﾛｰﾊﾞｰZ".HalfKatakanaToKatakana();
```

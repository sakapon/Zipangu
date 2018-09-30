## VisualBasic.Strings との互換性

このライブラリは、.NET Framework の Microsoft.VisualBasic.dll の [Strings.StrConv メソッド](https://docs.microsoft.com/dotnet/api/microsoft.visualbasic.strings.strconv)との互換性は完全ではありません。
とはいえ、ほぼ同じであり、それらの差異を以下に示します。

### AsciiToWide
| 入力 | Zipangu | VisualBasic.Strings |
-|-|-
| 005C `\` | `＼` | `\` |

### AsciiToNarrow
| 入力 | Zipangu | VisualBasic.Strings |
-|-|-
| FF3C `＼` | `\` | `＼` |

### HiraganaToKatakana
差異なし

### KatakanaToHiragana
| 入力 | Zipangu | VisualBasic.Strings |
-|-|-
| 3094 `ゔ` | `ゔ` | `ヴ` |
| 30F4 `ヴ` | `ゔ` | `ヴ` |
| 30F5 `ヵ` | `ヵ` | `?` |
| 30F6 `ヶ` | `ヶ` | `?` |

### HalfKatakanaToHiragana
| 入力 | Zipangu | VisualBasic.Strings |
-|-|-
| `ｳﾞ` | `ゔ` | `ヴ` |

### HalfKatakanaToKatakana
差異なし

### References
- [VisualBasic.Strings Test](../VBStringsTest)

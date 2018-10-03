## VisualBasic.Strings との互換性
このライブラリでは、.NET Framework の Microsoft.VisualBasic.dll の [Strings.StrConv メソッド](https://docs.microsoft.com/dotnet/api/microsoft.visualbasic.strings.strconv)との互換性は完全ではありません。
それらの差異を以下に示します。

### AsciiToWide
| 入力 | Zipangu | VisualBasic.Strings |
-|-|-
| 005C `\` | `＼` | `\` |

### AsciiToNarrow
| 入力 | Zipangu | VisualBasic.Strings |
-|-|-
| FF3C `＼` | `\` | `＼` |

### HiraganaToKatakana
| 入力 | Zipangu | VisualBasic.Strings |
-|-|-
| `ゕゖゟ゠ヷヸヹヺヿ` | 無変換 | `?` |

### KatakanaToHiragana
| 入力 | Zipangu | VisualBasic.Strings |
-|-|-
| 3094 `ゔ` | `ゔ` | `ヴ` |
| 30F4 `ヴ` | `ゔ` | `ヴ` |
| `ヵヶ` | 無変換 | `?` |
| `ゕゖゟ゠ヷヸヹヺヿ` | 無変換 | `?` |

### HalfKatakanaToHiragana
| 入力 | Zipangu | VisualBasic.Strings |
-|-|-
| `ｳﾞ` | `ゔ` | `ヴ` |
| `ヵヶ` | 無変換 | `?` |
| `ゕゖゟ゠ヷヸヹヺヿ` | 無変換 | `？` |

### HalfKatakanaToKatakana
| 入力 | Zipangu | VisualBasic.Strings |
-|-|-
| `ゕゖゟ゠ヷヸヹヺヿ` | 無変換 | `？` |

### References
- [VisualBasic.Strings のテスト データ](../VBStringsTest)

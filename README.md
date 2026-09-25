# Mutsuki

Mutsuki is a script dumper for *Sayonara o Oshiete*. It handles both the
Japanese original and the Chinese release; other AVG3217D novels are untested.

## Usage

```sh
# Japanese original - the text is plain Shift-JIS
Mutsuki -i SEEN.TXT -o ./out

# Chinese release - the text needs the glyph table
Mutsuki -i SEEN.TXT -o ./out -m big_cache_zip.json
```

## Mapping Table

The mapping file is in the Release,
the relationship is from `FN.DAT` Offset to the actual display of Chinese characters.

The Chinese release swaps the glyphs in `FN.DAT`, so its two-byte runs keep
Japanese code points but draw Chinese characters; `-m` resolves them. The
Japanese original needs no table, and passing one there silently replaces every
kanji with an unrelated character while leaving the kana intact, so the output
looks like text rather than like a failure.

## Thanks

- [Waffle](https://github.com/ruin0x11/waffle_osx)
- [Adieu](https://github.com/Ruin0x11/adieu)

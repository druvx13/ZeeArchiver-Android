/*
 * Copyright (c) 2018. Created by : Mahmoud Galal.
 * Support: mahmoudgalal57@yahoo.com
 */
package com.mg.zeearchiver.utils

import com.mg.zeearchiver.utils.compression.CFormatInfo

object Constants {
    val g_Levels = arrayOf(
        "Store",
        "Fastest",
        "",
        "Fast",
        "",
        "Normal",
        "",
        "Maximum",
        "",
        "Ultra"
    )

    enum class ELevel(val value: Int) {
        kStore(0),
        kFastest(1),
        kFast(3),
        kNormal(5),
        kMaximum(7),
        kUltra(9)
    }

    enum class EEnum {
        kAdd,
        kUpdate,
        kFresh,
        kSynchronize
    }

    enum class EMethodID {
        kCopy,
        kLZMA,
        kLZMA2,
        kPPMd,
        kBZip2,
        kDeflate,
        kDeflate64,
        kPPMdZip
    }

    val kMethodsNames = arrayOf(
        "Copy",
        "LZMA",
        "LZMA2",
        "PPMd",
        "BZip2",
        "Deflate",
        "Deflate64",
        "PPMd"
    )

    val g_7zMethods = arrayOf(
        EMethodID.kLZMA,
        EMethodID.kLZMA2,
        EMethodID.kPPMd,
        EMethodID.kBZip2
    )

    val g_7zSfxMethods = arrayOf(
        EMethodID.kCopy,
        EMethodID.kLZMA,
        EMethodID.kLZMA2,
        EMethodID.kPPMd
    )

    val g_ZipMethods = arrayOf(
        EMethodID.kDeflate,
        EMethodID.kDeflate64,
        EMethodID.kBZip2,
        EMethodID.kLZMA,
        EMethodID.kPPMdZip
    )

    val g_GZipMethods = arrayOf(
        EMethodID.kDeflate
    )

    val g_BZip2Methods = arrayOf(
        EMethodID.kBZip2
    )

    val g_XzMethods = arrayOf(
        EMethodID.kLZMA2
    )

    val g_Formats = arrayOf(
        CFormatInfo(
            "",
            (1 shl 0) or (1 shl 1) or (1 shl 3) or (1 shl 5) or (1 shl 7) or (1 shl 9),
            null, 0,
            false, false, false, false, false, false
        ),
        CFormatInfo(
            "7z",
            (1 shl 0) or (1 shl 1) or (1 shl 3) or (1 shl 5) or (1 shl 7) or (1 shl 9),
            g_7zMethods, g_7zMethods.size,
            true, true, true, true, true, true
        ),
        CFormatInfo(
            "Zip",
            (1 shl 0) or (1 shl 1) or (1 shl 3) or (1 shl 5) or (1 shl 7) or (1 shl 9),
            g_ZipMethods, g_ZipMethods.size,
            false, false, true, false, true, false
        ),
        CFormatInfo(
            "GZip",
            (1 shl 1) or (1 shl 5) or (1 shl 7) or (1 shl 9),
            g_GZipMethods, g_GZipMethods.size,
            false, false, false, false, false, false
        ),
        CFormatInfo(
            "BZip2",
            (1 shl 1) or (1 shl 3) or (1 shl 5) or (1 shl 7) or (1 shl 9),
            g_BZip2Methods, g_BZip2Methods.size,
            false, false, true, false, false, false
        ),
        CFormatInfo(
            "xz",
            (1 shl 1) or (1 shl 3) or (1 shl 5) or (1 shl 7) or (1 shl 9),
            g_XzMethods, g_XzMethods.size,
            false, false, true, false, false, false
        ),
        CFormatInfo(
            "Tar",
            (1 shl 0),
            null, 0,
            false, false, false, false, false, false
        ),
        CFormatInfo(
            "wim",
            (1 shl 0),
            null, 0,
            false, false, false, false, false, false
        )
    )
}

; ModuleID = 'obj\Debug\130\android\marshal_methods.x86.ll'
source_filename = "obj\Debug\130\android\marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [376 x i32] [
	i32 11257817, ; 0: OxyPlot.dll => 0xabc7d9 => 45
	i32 32687329, ; 1: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 115
	i32 34715100, ; 2: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 158
	i32 39109920, ; 3: Newtonsoft.Json.dll => 0x254c520 => 44
	i32 57263871, ; 4: Xamarin.Forms.Core.dll => 0x369c6ff => 150
	i32 65901613, ; 5: MathNet.Numerics => 0x3ed942d => 27
	i32 68219467, ; 6: System.Security.Cryptography.Primitives => 0x410f24b => 15
	i32 87464900, ; 7: azizapp.Android => 0x5369bc4 => 1
	i32 101534019, ; 8: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 129
	i32 103834273, ; 9: Xamarin.Firebase.Annotations.dll => 0x63062a1 => 139
	i32 120558881, ; 10: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 129
	i32 149972175, ; 11: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 15
	i32 165246403, ; 12: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 95
	i32 182336117, ; 13: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 130
	i32 205943382, ; 14: WebSocket4Net => 0xc467256 => 84
	i32 209399409, ; 15: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 93
	i32 220171995, ; 16: System.Diagnostics.Debug => 0xd1f8edb => 10
	i32 230216969, ; 17: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 110
	i32 230752869, ; 18: Microsoft.CSharp.dll => 0xdc10265 => 34
	i32 232815796, ; 19: System.Web.Services => 0xde07cb4 => 174
	i32 261689757, ; 20: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 98
	i32 276479776, ; 21: System.Threading.Timer.dll => 0x107abf20 => 14
	i32 278686392, ; 22: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 114
	i32 280482487, ; 23: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 108
	i32 287869112, ; 24: Syncfusion.SfChart.XForms.dll => 0x112888b8 => 67
	i32 318968648, ; 25: Xamarin.AndroidX.Activity.dll => 0x13031348 => 85
	i32 321597661, ; 26: System.Numerics => 0x132b30dd => 76
	i32 339909257, ; 27: Fabulous => 0x14429a89 => 19
	i32 342366114, ; 28: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 112
	i32 347068432, ; 29: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0x14afd810 => 58
	i32 385762202, ; 30: System.Memory.dll => 0x16fe439a => 73
	i32 393699800, ; 31: Firebase => 0x177761d8 => 22
	i32 441335492, ; 32: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 97
	i32 442521989, ; 33: Xamarin.Essentials => 0x1a605985 => 138
	i32 442565967, ; 34: System.Collections => 0x1a61054f => 5
	i32 450948140, ; 35: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 107
	i32 451504562, ; 36: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 180
	i32 465846621, ; 37: mscorlib => 0x1bc4415d => 43
	i32 469710990, ; 38: System.dll => 0x1bff388e => 71
	i32 476646585, ; 39: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 108
	i32 485140951, ; 40: Xamarin.Google.Android.DataTransport.TransportRuntime => 0x1ceaa9d7 => 156
	i32 486930444, ; 41: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 119
	i32 495452658, ; 42: Xamarin.Google.Android.DataTransport.TransportRuntime.dll => 0x1d8801f2 => 156
	i32 504143952, ; 43: Plugin.LocalNotification.dll => 0x1e0ca050 => 50
	i32 507148113, ; 44: Xamarin.Google.Android.DataTransport.TransportApi.dll => 0x1e3a7751 => 154
	i32 513247710, ; 45: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 40
	i32 525008092, ; 46: SkiaSharp.dll => 0x1f4afcdc => 52
	i32 526420162, ; 47: System.Transactions.dll => 0x1f6088c2 => 173
	i32 539058512, ; 48: Microsoft.Extensions.Logging => 0x20216150 => 38
	i32 542030372, ; 49: Xamarin.GooglePlayServices.Stats => 0x204eba24 => 163
	i32 545304856, ; 50: System.Runtime.Extensions => 0x2080b118 => 178
	i32 605376203, ; 51: System.IO.Compression.FileSystem => 0x24154ecb => 171
	i32 610194910, ; 52: System.Reactive.dll => 0x245ed5de => 78
	i32 613668793, ; 53: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 186
	i32 627609679, ; 54: Xamarin.AndroidX.CustomView => 0x2568904f => 103
	i32 662205335, ; 55: System.Text.Encodings.Web.dll => 0x27787397 => 81
	i32 663517072, ; 56: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 135
	i32 666292255, ; 57: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 90
	i32 683518922, ; 58: System.Net.Security => 0x28bdabca => 8
	i32 690569205, ; 59: System.Xml.Linq.dll => 0x29293ff5 => 83
	i32 700284507, ; 60: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 166
	i32 719061231, ; 61: Syncfusion.Core.XForms.dll => 0x2adc00ef => 62
	i32 748832960, ; 62: SQLitePCLRaw.batteries_v2 => 0x2ca248c0 => 56
	i32 775507847, ; 63: System.IO.Compression => 0x2e394f87 => 170
	i32 789151979, ; 64: Microsoft.Extensions.Options => 0x2f0980eb => 39
	i32 809851609, ; 65: System.Drawing.Common.dll => 0x30455ad9 => 11
	i32 843511501, ; 66: Xamarin.AndroidX.Print => 0x3246f6cd => 126
	i32 846667644, ; 67: Xamarin.Firebase.Installations.dll => 0x32771f7c => 146
	i32 869110404, ; 68: Fabulous.dll => 0x33cd9284 => 19
	i32 882434999, ; 69: Xamarin.Firebase.Installations.InterOp.dll => 0x3498e3b7 => 147
	i32 886248193, ; 70: Microcharts.Droid => 0x34d31301 => 28
	i32 928116545, ; 71: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 158
	i32 955402788, ; 72: Newtonsoft.Json => 0x38f24a24 => 44
	i32 967690846, ; 73: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 112
	i32 974778368, ; 74: FormsViewGroup.dll => 0x3a19f000 => 23
	i32 992768348, ; 75: System.Collections.dll => 0x3b2c715c => 5
	i32 996733531, ; 76: Xamarin.Google.Android.DataTransport.TransportBackendCct => 0x3b68f25b => 155
	i32 1012816738, ; 77: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 128
	i32 1028951442, ; 78: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 35
	i32 1035644815, ; 79: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 89
	i32 1036359102, ; 80: Xamarin.GooglePlayServices.CloudMessaging.dll => 0x3dc595be => 161
	i32 1042160112, ; 81: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 152
	i32 1052210849, ; 82: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 116
	i32 1084122840, ; 83: Xamarin.Kotlin.StdLib => 0x409e66d8 => 168
	i32 1098259244, ; 84: System => 0x41761b2c => 71
	i32 1141947663, ; 85: Xamarin.Firebase.Measurement.Connector.dll => 0x4410bd0f => 148
	i32 1175144683, ; 86: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 133
	i32 1178241025, ; 87: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 123
	i32 1204270330, ; 88: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 90
	i32 1217251461, ; 89: Fabulous.XamarinForms => 0x488dc885 => 20
	i32 1220193633, ; 90: Microsoft.Net.Http.Headers => 0x48baad61 => 41
	i32 1267360935, ; 91: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 134
	i32 1292207520, ; 92: SQLitePCLRaw.core.dll => 0x4d0585a0 => 57
	i32 1293217323, ; 93: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 105
	i32 1309284514, ; 94: Plugin.FirebasePushNotification => 0x4e0a18a2 => 49
	i32 1310647349, ; 95: WebSocket4Net.dll => 0x4e1ee435 => 84
	i32 1324164729, ; 96: System.Linq => 0x4eed2679 => 185
	i32 1333047053, ; 97: Xamarin.Firebase.Common => 0x4f74af0d => 140
	i32 1364015309, ; 98: System.IO => 0x514d38cd => 181
	i32 1365406463, ; 99: System.ServiceModel.Internals.dll => 0x516272ff => 175
	i32 1376866003, ; 100: Xamarin.AndroidX.SavedState => 0x52114ed3 => 128
	i32 1379897097, ; 101: Xamarin.JavaX.Inject => 0x523f8f09 => 165
	i32 1395857551, ; 102: Xamarin.AndroidX.Media.dll => 0x5333188f => 120
	i32 1406073936, ; 103: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 99
	i32 1411638395, ; 104: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 79
	i32 1452756204, ; 105: Syncfusion.Expander.XForms.Android.dll => 0x56974cec => 63
	i32 1457743152, ; 106: System.Runtime.Extensions.dll => 0x56e36530 => 178
	i32 1458022317, ; 107: System.Net.Security.dll => 0x56e7a7ad => 8
	i32 1460219004, ; 108: Xamarin.Forms.Xaml => 0x57092c7c => 153
	i32 1462112819, ; 109: System.IO.Compression.dll => 0x57261233 => 170
	i32 1469204771, ; 110: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 88
	i32 1470490898, ; 111: Microsoft.Extensions.Primitives => 0x57a5e912 => 40
	i32 1516315406, ; 112: Syncfusion.Core.XForms.Android.dll => 0x5a61230e => 61
	i32 1520711082, ; 113: Syncfusion.SfChart.XForms.Android.dll => 0x5aa435aa => 66
	i32 1524747670, ; 114: Plugin.LocalNotification => 0x5ae1cd96 => 50
	i32 1525073972, ; 115: azizapp.Android.dll => 0x5ae6c834 => 1
	i32 1531040989, ; 116: Xamarin.Firebase.Iid.Interop.dll => 0x5b41d4dd => 145
	i32 1543031311, ; 117: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 187
	i32 1582372066, ; 118: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 104
	i32 1582526884, ; 119: Microcharts.Forms.dll => 0x5e5371a4 => 29
	i32 1592978981, ; 120: System.Runtime.Serialization.dll => 0x5ef2ee25 => 16
	i32 1622152042, ; 121: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 118
	i32 1624863272, ; 122: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 137
	i32 1632079564, ; 123: Microsoft.AspNet.SignalR.Client.dll => 0x61478ecc => 30
	i32 1636350590, ; 124: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 102
	i32 1639515021, ; 125: System.Net.Http.dll => 0x61b9038d => 74
	i32 1639986890, ; 126: System.Text.RegularExpressions => 0x61c036ca => 187
	i32 1657153582, ; 127: System.Runtime => 0x62c6282e => 80
	i32 1658241508, ; 128: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 131
	i32 1658251792, ; 129: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 157
	i32 1670060433, ; 130: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 98
	i32 1677501392, ; 131: System.Net.Primitives.dll => 0x63fca3d0 => 7
	i32 1698840827, ; 132: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 167
	i32 1701541528, ; 133: System.Diagnostics.Debug.dll => 0x656b7698 => 10
	i32 1705516310, ; 134: FSharp.Core => 0x65a81d16 => 24
	i32 1711441057, ; 135: SQLitePCLRaw.lib.e_sqlite3.android => 0x660284a1 => 58
	i32 1722051300, ; 136: SkiaSharp.Views.Forms => 0x66a46ae4 => 54
	i32 1726116996, ; 137: System.Reflection.dll => 0x66e27484 => 184
	i32 1729485958, ; 138: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 94
	i32 1746115085, ; 139: System.IO.Pipelines.dll => 0x68139a0d => 72
	i32 1766324549, ; 140: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 130
	i32 1770582343, ; 141: Microsoft.Extensions.Logging.dll => 0x6988f147 => 38
	i32 1776026572, ; 142: System.Core.dll => 0x69dc03cc => 69
	i32 1777771020, ; 143: azizapp => 0x69f6a20c => 17
	i32 1788241197, ; 144: Xamarin.AndroidX.Fragment => 0x6a96652d => 107
	i32 1808609942, ; 145: Xamarin.AndroidX.Loader => 0x6bcd3296 => 118
	i32 1813058853, ; 146: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 168
	i32 1813201214, ; 147: Xamarin.Google.Android.Material => 0x6c13413e => 157
	i32 1818569960, ; 148: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 124
	i32 1819327070, ; 149: Microsoft.AspNetCore.Http.Features.dll => 0x6c70ba5e => 32
	i32 1828515996, ; 150: FSharp.Core.dll => 0x6cfcf09c => 24
	i32 1828688058, ; 151: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 37
	i32 1867746548, ; 152: Xamarin.Essentials.dll => 0x6f538cf4 => 138
	i32 1878053835, ; 153: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 153
	i32 1885316902, ; 154: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 91
	i32 1904755420, ; 155: System.Runtime.InteropServices.WindowsRuntime.dll => 0x718842dc => 13
	i32 1908813208, ; 156: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 160
	i32 1919157823, ; 157: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 121
	i32 1928288591, ; 158: Microsoft.AspNetCore.Http.Abstractions => 0x72ef594f => 31
	i32 1933215285, ; 159: Xamarin.Firebase.Messaging.dll => 0x733a8635 => 149
	i32 1983156543, ; 160: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 167
	i32 2011961780, ; 161: System.Buffers.dll => 0x77ec19b4 => 68
	i32 2019465201, ; 162: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 116
	i32 2055257422, ; 163: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 113
	i32 2075706075, ; 164: Microsoft.AspNetCore.Http.Abstractions.dll => 0x7bb8c2db => 31
	i32 2079903147, ; 165: System.Runtime.dll => 0x7bf8cdab => 80
	i32 2090596640, ; 166: System.Numerics.Vectors => 0x7c9bf920 => 77
	i32 2092734687, ; 167: Microsoft.AspNetCore.JsonPatch => 0x7cbc98df => 33
	i32 2097448633, ; 168: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 109
	i32 2103459038, ; 169: SQLitePCLRaw.provider.e_sqlite3.dll => 0x7d603cde => 59
	i32 2124230737, ; 170: Xamarin.Google.Android.DataTransport.TransportBackendCct.dll => 0x7e9d3051 => 155
	i32 2126786730, ; 171: Xamarin.Forms.Platform.Android => 0x7ec430aa => 151
	i32 2129483829, ; 172: Xamarin.GooglePlayServices.Base.dll => 0x7eed5835 => 159
	i32 2133113917, ; 173: Syncfusion.SfChart.XForms => 0x7f24bc3d => 67
	i32 2142473426, ; 174: System.Collections.Specialized => 0x7fb38cd2 => 179
	i32 2174878672, ; 175: Xamarin.Firebase.Annotations => 0x81a203d0 => 139
	i32 2181898931, ; 176: Microsoft.Extensions.Options.dll => 0x820d22b3 => 39
	i32 2192057212, ; 177: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 37
	i32 2198219022, ; 178: MathNet.Numerics.dll => 0x8306290e => 27
	i32 2201231467, ; 179: System.Net.Http => 0x8334206b => 74
	i32 2217644978, ; 180: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 133
	i32 2239267700, ; 181: FSharp.Core.resources => 0x85788374 => 0
	i32 2240986525, ; 182: Microsoft.AspNet.SignalR.Client => 0x8592bd9d => 30
	i32 2244775296, ; 183: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 119
	i32 2256548716, ; 184: Xamarin.AndroidX.MultiDex => 0x8680336c => 121
	i32 2261435625, ; 185: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 111
	i32 2279755925, ; 186: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 127
	i32 2295906218, ; 187: System.Net.Sockets => 0x88d8bfaa => 177
	i32 2306217607, ; 188: OxyPlot.Xamarin.Forms => 0x89761687 => 47
	i32 2315684594, ; 189: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 86
	i32 2343171156, ; 190: Syncfusion.Core.XForms => 0x8ba9f454 => 62
	i32 2353062107, ; 191: System.Net.Primitives => 0x8c40e0db => 7
	i32 2354730003, ; 192: Syncfusion.Licensing => 0x8c5a5413 => 65
	i32 2409053734, ; 193: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 125
	i32 2435179157, ; 194: azizapp.dll => 0x9125e295 => 17
	i32 2454642406, ; 195: System.Text.Encoding.dll => 0x924edee6 => 4
	i32 2458678730, ; 196: System.Net.Sockets.dll => 0x928c75ca => 177
	i32 2465273461, ; 197: SQLitePCLRaw.batteries_v2.dll => 0x92f11675 => 56
	i32 2465532216, ; 198: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 97
	i32 2471841756, ; 199: netstandard.dll => 0x93554fdc => 2
	i32 2475788418, ; 200: Java.Interop.dll => 0x93918882 => 25
	i32 2483661569, ; 201: Xamarin.Firebase.Measurement.Connector => 0x9409ab01 => 148
	i32 2483742551, ; 202: Xamarin.Firebase.Messaging => 0x940ae757 => 149
	i32 2486410006, ; 203: Xamarin.GooglePlayServices.CloudMessaging => 0x94339b16 => 161
	i32 2501346920, ; 204: System.Data.DataSetExtensions => 0x95178668 => 169
	i32 2505855802, ; 205: Fabulous.XamarinForms.OxyPlot => 0x955c533a => 21
	i32 2505896520, ; 206: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 115
	i32 2528662365, ; 207: Microsoft.AspNetCore.JsonPatch.dll => 0x96b8535d => 33
	i32 2562349572, ; 208: Microsoft.CSharp => 0x98ba5a04 => 34
	i32 2568748418, ; 209: OxyPlot.Xamarin.Forms.Platform.Android => 0x991bfd82 => 48
	i32 2570120770, ; 210: System.Text.Encodings.Web => 0x9930ee42 => 81
	i32 2581819634, ; 211: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 134
	i32 2582980004, ; 212: Fabulous.XamarinForms.OxyPlot.dll => 0x99f525a4 => 21
	i32 2620111890, ; 213: Xamarin.Firebase.Encoders.dll => 0x9c2bbc12 => 143
	i32 2620871830, ; 214: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 102
	i32 2623491480, ; 215: Xamarin.Firebase.Installations.InterOp => 0x9c5f4d98 => 147
	i32 2624644809, ; 216: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 106
	i32 2624721879, ; 217: Syncfusion.SfChart.XForms.Android => 0x9c7213d7 => 66
	i32 2633051222, ; 218: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 114
	i32 2639764100, ; 219: Xamarin.Firebase.Encoders => 0x9d579a84 => 143
	i32 2642291320, ; 220: System.Net.WebSockets.WebSocketProtocol.dll => 0x9d7e2a78 => 75
	i32 2689529426, ; 221: OxyPlot.Xamarin.Android => 0xa04ef652 => 46
	i32 2693849962, ; 222: System.IO.dll => 0xa090e36a => 181
	i32 2701096212, ; 223: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 131
	i32 2715334215, ; 224: System.Threading.Tasks.dll => 0xa1d8b647 => 9
	i32 2724373263, ; 225: System.Runtime.Numerics.dll => 0xa262a30f => 176
	i32 2732626843, ; 226: Xamarin.AndroidX.Activity => 0xa2e0939b => 85
	i32 2737747696, ; 227: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 88
	i32 2747619038, ; 228: OxyPlot.Xamarin.Android.dll => 0xa3c556de => 46
	i32 2766581644, ; 229: Xamarin.Forms.Core => 0xa4e6af8c => 150
	i32 2768457651, ; 230: PropertyChanged => 0xa5034fb3 => 51
	i32 2770495804, ; 231: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 166
	i32 2778768386, ; 232: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 136
	i32 2795602088, ; 233: SkiaSharp.Views.Android.dll => 0xa6a180a8 => 53
	i32 2804607052, ; 234: Xamarin.Firebase.Components.dll => 0xa72ae84c => 141
	i32 2810250172, ; 235: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 99
	i32 2819470561, ; 236: System.Xml.dll => 0xa80db4e1 => 82
	i32 2847418871, ; 237: Xamarin.GooglePlayServices.Base => 0xa9b829f7 => 159
	i32 2850549256, ; 238: Microsoft.AspNetCore.Http.Features => 0xa9e7ee08 => 32
	i32 2853208004, ; 239: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 136
	i32 2855708567, ; 240: Xamarin.AndroidX.Transition => 0xaa36a797 => 132
	i32 2868557005, ; 241: Syncfusion.Licensing.dll => 0xaafab4cd => 65
	i32 2874148507, ; 242: Syncfusion.Core.XForms.Android => 0xab50069b => 61
	i32 2883826422, ; 243: Xamarin.Firebase.Installations => 0xabe3b2f6 => 146
	i32 2901442782, ; 244: System.Reflection => 0xacf080de => 184
	i32 2903344695, ; 245: System.ComponentModel.Composition => 0xad0d8637 => 172
	i32 2905242038, ; 246: mscorlib.dll => 0xad2a79b6 => 43
	i32 2912489636, ; 247: SkiaSharp.Views.Android => 0xad9910a4 => 53
	i32 2914202368, ; 248: Xamarin.Firebase.Iid.Interop => 0xadb33300 => 145
	i32 2916838712, ; 249: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 137
	i32 2919462931, ; 250: System.Numerics.Vectors.dll => 0xae037813 => 77
	i32 2921128767, ; 251: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 87
	i32 2972252294, ; 252: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 186
	i32 2974793899, ; 253: SkiaSharp.Views.Forms.dll => 0xb14fc0ab => 54
	i32 2978675010, ; 254: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 105
	i32 3024354802, ; 255: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 110
	i32 3036068679, ; 256: Microcharts.Droid.dll => 0xb4f6bb47 => 28
	i32 3044182254, ; 257: FormsViewGroup => 0xb57288ee => 23
	i32 3057625584, ; 258: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 122
	i32 3058099980, ; 259: Xamarin.GooglePlayServices.Tasks => 0xb646e70c => 164
	i32 3071899978, ; 260: Xamarin.Firebase.Common.dll => 0xb719794a => 140
	i32 3075834255, ; 261: System.Threading.Tasks => 0xb755818f => 9
	i32 3085392760, ; 262: OxyPlot => 0xb7e75b78 => 45
	i32 3090735792, ; 263: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 180
	i32 3106737866, ; 264: Xamarin.Firebase.Datatransport.dll => 0xb92d0eca => 142
	i32 3111772706, ; 265: System.Runtime.Serialization => 0xb979e222 => 16
	i32 3124832203, ; 266: System.Threading.Tasks.Extensions => 0xba4127cb => 183
	i32 3147431871, ; 267: OxyPlot.Xamarin.Forms.dll => 0xbb99ffbf => 47
	i32 3155362983, ; 268: Xamarin.Google.Android.DataTransport.TransportApi => 0xbc1304a7 => 154
	i32 3204380047, ; 269: System.Data.dll => 0xbefef58f => 12
	i32 3211777861, ; 270: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 104
	i32 3220365878, ; 271: System.Threading => 0xbff2e236 => 6
	i32 3223546065, ; 272: Syncfusion.Expander.XForms => 0xc02368d1 => 64
	i32 3230466174, ; 273: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 160
	i32 3247949154, ; 274: Mono.Security => 0xc197c562 => 182
	i32 3258312781, ; 275: Xamarin.AndroidX.CardView => 0xc235e84d => 94
	i32 3265893370, ; 276: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 183
	i32 3267021929, ; 277: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 92
	i32 3286872994, ; 278: SQLite-net.dll => 0xc3e9b3a2 => 55
	i32 3299363146, ; 279: System.Text.Encoding => 0xc4a8494a => 4
	i32 3317135071, ; 280: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 103
	i32 3317144872, ; 281: System.Data => 0xc5b79d28 => 12
	i32 3322403133, ; 282: Firebase.dll => 0xc607d93d => 22
	i32 3331531814, ; 283: Xamarin.GooglePlayServices.Stats.dll => 0xc6932426 => 163
	i32 3340387945, ; 284: SkiaSharp => 0xc71a4669 => 52
	i32 3340431453, ; 285: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 91
	i32 3346324047, ; 286: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 123
	i32 3353484488, ; 287: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 109
	i32 3360279109, ; 288: SQLitePCLRaw.core => 0xc849ca45 => 57
	i32 3362522851, ; 289: Xamarin.AndroidX.Core => 0xc86c06e3 => 101
	i32 3366347497, ; 290: Java.Interop => 0xc8a662e9 => 25
	i32 3374999561, ; 291: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 127
	i32 3381829691, ; 292: SuperSocket.ClientEngine => 0xc992a03b => 60
	i32 3383578424, ; 293: Xamarin.Firebase.Encoders.JSON => 0xc9ad4f38 => 144
	i32 3395150330, ; 294: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 79
	i32 3401559547, ; 295: Plugin.FirebasePushNotification.dll => 0xcabfadfb => 49
	i32 3404865022, ; 296: System.ServiceModel.Internals => 0xcaf21dfe => 175
	i32 3428513518, ; 297: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 36
	i32 3429136800, ; 298: System.Xml => 0xcc6479a0 => 82
	i32 3430777524, ; 299: netstandard => 0xcc7d82b4 => 2
	i32 3436126843, ; 300: FSharp.Core.resources.dll => 0xcccf227b => 0
	i32 3441283291, ; 301: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 106
	i32 3455791806, ; 302: Microcharts => 0xcdfb32be => 3
	i32 3476120550, ; 303: Mono.Android => 0xcf3163e6 => 42
	i32 3486566296, ; 304: System.Transactions => 0xcfd0c798 => 173
	i32 3493954962, ; 305: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 96
	i32 3494395880, ; 306: Xamarin.GooglePlayServices.Location.dll => 0xd0483fe8 => 162
	i32 3499824017, ; 307: Syncfusion.Expander.XForms.dll => 0xd09b1391 => 64
	i32 3501239056, ; 308: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 92
	i32 3509114376, ; 309: System.Xml.Linq => 0xd128d608 => 83
	i32 3536029504, ; 310: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 151
	i32 3560100363, ; 311: System.Threading.Timer => 0xd432d20b => 14
	i32 3567349600, ; 312: System.ComponentModel.Composition.dll => 0xd4a16f60 => 172
	i32 3594787188, ; 313: System.Net.WebSockets.WebSocketProtocol => 0xd6441974 => 75
	i32 3596207933, ; 314: LiteDB.dll => 0xd659c73d => 26
	i32 3608519521, ; 315: System.Linq.dll => 0xd715a361 => 185
	i32 3618140916, ; 316: Xamarin.AndroidX.Preference => 0xd7a872f4 => 125
	i32 3625525219, ; 317: DropdownMenu.dll => 0xd8191fe3 => 18
	i32 3627220390, ; 318: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 126
	i32 3629588173, ; 319: LiteDB => 0xd8571ecd => 26
	i32 3632359727, ; 320: Xamarin.Forms.Platform => 0xd881692f => 152
	i32 3633644679, ; 321: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 87
	i32 3641597786, ; 322: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 113
	i32 3668042751, ; 323: Microcharts.dll => 0xdaa1e3ff => 3
	i32 3672681054, ; 324: Mono.Android.dll => 0xdae8aa5e => 42
	i32 3676310014, ; 325: System.Web.Services.dll => 0xdb2009fe => 174
	i32 3682565725, ; 326: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 93
	i32 3684561358, ; 327: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 96
	i32 3684933406, ; 328: System.Runtime.InteropServices.WindowsRuntime => 0xdba39f1e => 13
	i32 3689375977, ; 329: System.Drawing.Common => 0xdbe768e9 => 11
	i32 3706696989, ; 330: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 100
	i32 3711641445, ; 331: DropdownMenu => 0xdd3b2765 => 18
	i32 3718780102, ; 332: Xamarin.AndroidX.Annotation => 0xdda814c6 => 86
	i32 3724971120, ; 333: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 122
	i32 3731644420, ; 334: System.Reactive => 0xde6c6004 => 78
	i32 3748608112, ; 335: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 70
	i32 3754567612, ; 336: SQLitePCLRaw.provider.e_sqlite3 => 0xdfca27bc => 59
	i32 3758932259, ; 337: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 111
	i32 3786282454, ; 338: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 95
	i32 3802395368, ; 339: System.Collections.Specialized.dll => 0xe2a3f2e8 => 179
	i32 3822602673, ; 340: Xamarin.AndroidX.Media => 0xe3d849b1 => 120
	i32 3829621856, ; 341: System.Numerics.dll => 0xe4436460 => 76
	i32 3841636137, ; 342: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 35
	i32 3849856203, ; 343: SuperSocket.ClientEngine.dll => 0xe57824cb => 60
	i32 3854864648, ; 344: OxyPlot.Xamarin.Forms.Platform.Android.dll => 0xe5c49108 => 48
	i32 3875965715, ; 345: Fabulous.XamarinForms.dll => 0xe7068b13 => 20
	i32 3876362041, ; 346: SQLite-net => 0xe70c9739 => 55
	i32 3885922214, ; 347: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 132
	i32 3896760992, ; 348: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 101
	i32 3903721208, ; 349: Microcharts.Forms => 0xe8ae0ef8 => 29
	i32 3920810846, ; 350: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 171
	i32 3921031405, ; 351: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 135
	i32 3931092270, ; 352: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 124
	i32 3934056515, ; 353: Xamarin.JavaX.Inject.dll => 0xea7cf043 => 165
	i32 3945713374, ; 354: System.Data.DataSetExtensions.dll => 0xeb2ecede => 169
	i32 3955647286, ; 355: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 89
	i32 3967165417, ; 356: Xamarin.GooglePlayServices.Location => 0xec7623e9 => 162
	i32 3970018735, ; 357: Xamarin.GooglePlayServices.Tasks.dll => 0xeca1adaf => 164
	i32 4004095362, ; 358: Syncfusion.Expander.XForms.Android => 0xeea9a582 => 63
	i32 4023392905, ; 359: System.IO.Pipelines => 0xefd01a89 => 72
	i32 4025784931, ; 360: System.Memory => 0xeff49a63 => 73
	i32 4044155772, ; 361: Microsoft.Net.Http.Headers.dll => 0xf10ceb7c => 41
	i32 4073602200, ; 362: System.Threading.dll => 0xf2ce3c98 => 6
	i32 4105002889, ; 363: Mono.Security.dll => 0xf4ad5f89 => 182
	i32 4126470640, ; 364: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 36
	i32 4151237749, ; 365: System.Core => 0xf76edc75 => 69
	i32 4182413190, ; 366: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 117
	i32 4184000013, ; 367: PropertyChanged.dll => 0xf962c60d => 51
	i32 4192648326, ; 368: Xamarin.Firebase.Encoders.JSON.dll => 0xf9e6bc86 => 144
	i32 4213026141, ; 369: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 70
	i32 4256097574, ; 370: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 100
	i32 4260525087, ; 371: System.Buffers => 0xfdf2741f => 68
	i32 4269159614, ; 372: Xamarin.Firebase.Datatransport => 0xfe7634be => 142
	i32 4274976490, ; 373: System.Runtime.Numerics => 0xfecef6ea => 176
	i32 4284549794, ; 374: Xamarin.Firebase.Components => 0xff610aa2 => 141
	i32 4292120959 ; 375: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 117
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [376 x i32] [
	i32 45, i32 115, i32 158, i32 44, i32 150, i32 27, i32 15, i32 1, ; 0..7
	i32 129, i32 139, i32 129, i32 15, i32 95, i32 130, i32 84, i32 93, ; 8..15
	i32 10, i32 110, i32 34, i32 174, i32 98, i32 14, i32 114, i32 108, ; 16..23
	i32 67, i32 85, i32 76, i32 19, i32 112, i32 58, i32 73, i32 22, ; 24..31
	i32 97, i32 138, i32 5, i32 107, i32 180, i32 43, i32 71, i32 108, ; 32..39
	i32 156, i32 119, i32 156, i32 50, i32 154, i32 40, i32 52, i32 173, ; 40..47
	i32 38, i32 163, i32 178, i32 171, i32 78, i32 186, i32 103, i32 81, ; 48..55
	i32 135, i32 90, i32 8, i32 83, i32 166, i32 62, i32 56, i32 170, ; 56..63
	i32 39, i32 11, i32 126, i32 146, i32 19, i32 147, i32 28, i32 158, ; 64..71
	i32 44, i32 112, i32 23, i32 5, i32 155, i32 128, i32 35, i32 89, ; 72..79
	i32 161, i32 152, i32 116, i32 168, i32 71, i32 148, i32 133, i32 123, ; 80..87
	i32 90, i32 20, i32 41, i32 134, i32 57, i32 105, i32 49, i32 84, ; 88..95
	i32 185, i32 140, i32 181, i32 175, i32 128, i32 165, i32 120, i32 99, ; 96..103
	i32 79, i32 63, i32 178, i32 8, i32 153, i32 170, i32 88, i32 40, ; 104..111
	i32 61, i32 66, i32 50, i32 1, i32 145, i32 187, i32 104, i32 29, ; 112..119
	i32 16, i32 118, i32 137, i32 30, i32 102, i32 74, i32 187, i32 80, ; 120..127
	i32 131, i32 157, i32 98, i32 7, i32 167, i32 10, i32 24, i32 58, ; 128..135
	i32 54, i32 184, i32 94, i32 72, i32 130, i32 38, i32 69, i32 17, ; 136..143
	i32 107, i32 118, i32 168, i32 157, i32 124, i32 32, i32 24, i32 37, ; 144..151
	i32 138, i32 153, i32 91, i32 13, i32 160, i32 121, i32 31, i32 149, ; 152..159
	i32 167, i32 68, i32 116, i32 113, i32 31, i32 80, i32 77, i32 33, ; 160..167
	i32 109, i32 59, i32 155, i32 151, i32 159, i32 67, i32 179, i32 139, ; 168..175
	i32 39, i32 37, i32 27, i32 74, i32 133, i32 0, i32 30, i32 119, ; 176..183
	i32 121, i32 111, i32 127, i32 177, i32 47, i32 86, i32 62, i32 7, ; 184..191
	i32 65, i32 125, i32 17, i32 4, i32 177, i32 56, i32 97, i32 2, ; 192..199
	i32 25, i32 148, i32 149, i32 161, i32 169, i32 21, i32 115, i32 33, ; 200..207
	i32 34, i32 48, i32 81, i32 134, i32 21, i32 143, i32 102, i32 147, ; 208..215
	i32 106, i32 66, i32 114, i32 143, i32 75, i32 46, i32 181, i32 131, ; 216..223
	i32 9, i32 176, i32 85, i32 88, i32 46, i32 150, i32 51, i32 166, ; 224..231
	i32 136, i32 53, i32 141, i32 99, i32 82, i32 159, i32 32, i32 136, ; 232..239
	i32 132, i32 65, i32 61, i32 146, i32 184, i32 172, i32 43, i32 53, ; 240..247
	i32 145, i32 137, i32 77, i32 87, i32 186, i32 54, i32 105, i32 110, ; 248..255
	i32 28, i32 23, i32 122, i32 164, i32 140, i32 9, i32 45, i32 180, ; 256..263
	i32 142, i32 16, i32 183, i32 47, i32 154, i32 12, i32 104, i32 6, ; 264..271
	i32 64, i32 160, i32 182, i32 94, i32 183, i32 92, i32 55, i32 4, ; 272..279
	i32 103, i32 12, i32 22, i32 163, i32 52, i32 91, i32 123, i32 109, ; 280..287
	i32 57, i32 101, i32 25, i32 127, i32 60, i32 144, i32 79, i32 49, ; 288..295
	i32 175, i32 36, i32 82, i32 2, i32 0, i32 106, i32 3, i32 42, ; 296..303
	i32 173, i32 96, i32 162, i32 64, i32 92, i32 83, i32 151, i32 14, ; 304..311
	i32 172, i32 75, i32 26, i32 185, i32 125, i32 18, i32 126, i32 26, ; 312..319
	i32 152, i32 87, i32 113, i32 3, i32 42, i32 174, i32 93, i32 96, ; 320..327
	i32 13, i32 11, i32 100, i32 18, i32 86, i32 122, i32 78, i32 70, ; 328..335
	i32 59, i32 111, i32 95, i32 179, i32 120, i32 76, i32 35, i32 60, ; 336..343
	i32 48, i32 20, i32 55, i32 132, i32 101, i32 29, i32 171, i32 135, ; 344..351
	i32 124, i32 165, i32 169, i32 89, i32 162, i32 164, i32 63, i32 72, ; 352..359
	i32 73, i32 41, i32 6, i32 182, i32 36, i32 69, i32 117, i32 51, ; 360..367
	i32 144, i32 70, i32 100, i32 68, i32 142, i32 176, i32 141, i32 117 ; 376..375
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" "stackrealign" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"NumRegisterParameters", i32 0}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}

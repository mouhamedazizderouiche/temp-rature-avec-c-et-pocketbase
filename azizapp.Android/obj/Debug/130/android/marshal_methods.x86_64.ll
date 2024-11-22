; ModuleID = 'obj\Debug\130\android\marshal_methods.x86_64.ll'
source_filename = "obj\Debug\130\android\marshal_methods.x86_64.ll"
target datalayout = "e-m:e-p270:32:32-p271:32:32-p272:64:64-i64:64-f80:128-n8:16:32:64-S128"
target triple = "x86_64-unknown-linux-android"


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
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 8
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [376 x i64] [
	i64 24362543149721218, ; 0: Xamarin.AndroidX.DynamicAnimation => 0x568d9a9a43a682 => 106
	i64 36418902923615093, ; 1: Plugin.LocalNotification => 0x8162cc9bdf1b75 => 50
	i64 98382396393917666, ; 2: Microsoft.Extensions.Primitives.dll => 0x15d8644ad360ce2 => 40
	i64 120698629574877762, ; 3: Mono.Android => 0x1accec39cafe242 => 42
	i64 181099460066822533, ; 4: Microcharts.Droid.dll => 0x28364ffda4c4985 => 28
	i64 210515253464952879, ; 5: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 95
	i64 232391251801502327, ; 6: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 128
	i64 295915112840604065, ; 7: Xamarin.AndroidX.SlidingPaneLayout => 0x41b4d3a3088a9a1 => 129
	i64 316157742385208084, ; 8: Xamarin.AndroidX.Core.Core.Ktx.dll => 0x46337caa7dc1b14 => 100
	i64 435170709725415398, ; 9: Xamarin.GooglePlayServices.Location => 0x60a097471d687e6 => 162
	i64 464346026994987652, ; 10: System.Reactive.dll => 0x671b04057e67284 => 78
	i64 627200827541438871, ; 11: OxyPlot.Xamarin.Forms.Platform.Android => 0x8b443d460704197 => 48
	i64 634308326490598313, ; 12: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x8cd840fee8b6ba9 => 115
	i64 687654259221141486, ; 13: Xamarin.GooglePlayServices.Base => 0x98b09e7c92917ee => 159
	i64 702024105029695270, ; 14: System.Drawing.Common => 0x9be17343c0e7726 => 11
	i64 720058930071658100, ; 15: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 109
	i64 870603111519317375, ; 16: SQLitePCLRaw.lib.e_sqlite3.android => 0xc1500ead2756d7f => 58
	i64 872800313462103108, ; 17: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 105
	i64 887546508555532406, ; 18: Microcharts.Forms => 0xc5132d8dc173876 => 29
	i64 940822596282819491, ; 19: System.Transactions => 0xd0e792aa81923a3 => 173
	i64 990502365984941804, ; 20: MathNet.Numerics => 0xdbef8a769b766ec => 27
	i64 996343623809489702, ; 21: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 152
	i64 1000557547492888992, ; 22: Mono.Security.dll => 0xde2b1c9cba651a0 => 182
	i64 1120440138749646132, ; 23: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 157
	i64 1202444765235964449, ; 24: Syncfusion.Expander.XForms.dll => 0x10aff124a5eaea21 => 64
	i64 1301485588176585670, ; 25: SQLitePCLRaw.core => 0x120fce3f338e43c6 => 57
	i64 1305438955564400107, ; 26: Fabulous.XamarinForms => 0x121dd9d0465f7deb => 20
	i64 1315114680217950157, ; 27: Xamarin.AndroidX.Arch.Core.Common.dll => 0x124039d5794ad7cd => 90
	i64 1416135423712704079, ; 28: Microcharts => 0x13a71faa343e364f => 3
	i64 1425944114962822056, ; 29: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 16
	i64 1465843056802068477, ; 30: Xamarin.Firebase.Components.dll => 0x1457b87e6928f7fd => 141
	i64 1476839205573959279, ; 31: System.Net.Primitives.dll => 0x147ec96ece9b1e6f => 7
	i64 1518315023656898250, ; 32: SQLitePCLRaw.provider.e_sqlite3 => 0x151223783a354eca => 59
	i64 1624659445732251991, ; 33: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 88
	i64 1628611045998245443, ; 34: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 117
	i64 1636321030536304333, ; 35: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0x16b5614ec39e16cd => 110
	i64 1653644849046973826, ; 36: System.Net.WebSockets.WebSocketProtocol => 0x16f2ed3a94196d82 => 75
	i64 1731380447121279447, ; 37: Newtonsoft.Json => 0x18071957e9b889d7 => 44
	i64 1743969030606105336, ; 38: System.Memory.dll => 0x1833d297e88f2af8 => 73
	i64 1795316252682057001, ; 39: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 89
	i64 1836611346387731153, ; 40: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 128
	i64 1837131419302612636, ; 41: Xamarin.Google.Android.DataTransport.TransportBackendCct.dll => 0x197ecd4ad53dce9c => 155
	i64 1875917498431009007, ; 42: Xamarin.AndroidX.Annotation.dll => 0x1a08990699eb70ef => 86
	i64 1972385128188460614, ; 43: System.Security.Cryptography.Algorithms => 0x1b5f51d2edefbe46 => 186
	i64 1981742497975770890, ; 44: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 116
	i64 2040001226662520565, ; 45: System.Threading.Tasks.Extensions.dll => 0x1c4f8a4ea894a6f5 => 183
	i64 2076847052340733488, ; 46: Syncfusion.Core.XForms => 0x1cd27163f7962630 => 62
	i64 2101320336680922033, ; 47: azizapp => 0x1d2963b6832babb1 => 17
	i64 2133195048986300728, ; 48: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 44
	i64 2134971073272545971, ; 49: Microsoft.AspNet.SignalR.Client.dll => 0x1da0f0e12c2502b3 => 30
	i64 2136356949452311481, ; 50: Xamarin.AndroidX.MultiDex.dll => 0x1da5dd539d8acbb9 => 121
	i64 2137969380975227603, ; 51: PropertyChanged => 0x1dab97d315b0b2d3 => 51
	i64 2165725771938924357, ; 52: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 93
	i64 2262844636196693701, ; 53: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 105
	i64 2284400282711631002, ; 54: System.Web.Services => 0x1fb3d1f42fd4249a => 174
	i64 2329709569556905518, ; 55: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 113
	i64 2333304172240924284, ; 56: azizapp.dll => 0x20618fc8435b6e7c => 17
	i64 2335503487726329082, ; 57: System.Text.Encodings.Web => 0x2069600c4d9d1cfa => 81
	i64 2337758774805907496, ; 58: System.Runtime.CompilerServices.Unsafe => 0x207163383edbc828 => 79
	i64 2463182746987656754, ; 59: MathNet.Numerics.dll => 0x222efba86b11f632 => 27
	i64 2469392061734276978, ; 60: Syncfusion.Core.XForms.Android.dll => 0x22450aff2ad74f72 => 61
	i64 2470498323731680442, ; 61: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 99
	i64 2479423007379663237, ; 62: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x2268ae16b2cba985 => 133
	i64 2497223385847772520, ; 63: System.Runtime => 0x22a7eb7046413568 => 80
	i64 2547086958574651984, ; 64: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 85
	i64 2592350477072141967, ; 65: System.Xml.dll => 0x23f9e10627330e8f => 82
	i64 2624866290265602282, ; 66: mscorlib.dll => 0x246d65fbde2db8ea => 43
	i64 2656907746661064104, ; 67: Microsoft.Extensions.DependencyInjection => 0x24df3b84c8b75da8 => 36
	i64 2694427813909235223, ; 68: Xamarin.AndroidX.Preference.dll => 0x256487d230fe0617 => 125
	i64 2783046991838674048, ; 69: System.Runtime.CompilerServices.Unsafe.dll => 0x269f5e7e6dc37c80 => 79
	i64 2960931600190307745, ; 70: Xamarin.Forms.Core => 0x2917579a49927da1 => 150
	i64 3017704767998173186, ; 71: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 157
	i64 3122911337338800527, ; 72: Microcharts.dll => 0x2b56cf50bf1e898f => 3
	i64 3143515969535650208, ; 73: Xamarin.Firebase.Encoders => 0x2ba0031e85f0a9a0 => 143
	i64 3217286949467762653, ; 74: Syncfusion.SfChart.XForms.Android.dll => 0x2ca6196f4386afdd => 66
	i64 3289520064315143713, ; 75: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 112
	i64 3303437397778967116, ; 76: Xamarin.AndroidX.Annotation.Experimental => 0x2dd82acf985b2a4c => 87
	i64 3311221304742556517, ; 77: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 77
	i64 3325875462027654285, ; 78: System.Runtime.Numerics => 0x2e27e21c8958b48d => 176
	i64 3328853167529574890, ; 79: System.Net.Sockets.dll => 0x2e327651a008c1ea => 177
	i64 3364695309916733813, ; 80: Xamarin.Firebase.Common => 0x2eb1cc8eb5028175 => 140
	i64 3411255996856937470, ; 81: Xamarin.GooglePlayServices.Basement => 0x2f5737416a942bfe => 160
	i64 3493805808809882663, ; 82: Xamarin.AndroidX.Tracing.Tracing.dll => 0x307c7ddf444f3427 => 131
	i64 3522470458906976663, ; 83: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 130
	i64 3531994851595924923, ; 84: System.Numerics => 0x31042a9aade235bb => 76
	i64 3571415421602489686, ; 85: System.Runtime.dll => 0x319037675df7e556 => 80
	i64 3716579019761409177, ; 86: netstandard.dll => 0x3393f0ed5c8c5c99 => 2
	i64 3727469159507183293, ; 87: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 127
	i64 3772598417116884899, ; 88: Xamarin.AndroidX.DynamicAnimation.dll => 0x345af645b473efa3 => 106
	i64 3869221888984012293, ; 89: Microsoft.Extensions.Logging.dll => 0x35b23cceda0ed605 => 38
	i64 3966267475168208030, ; 90: System.Memory => 0x370b03412596249e => 73
	i64 4201423742386704971, ; 91: Xamarin.AndroidX.Core.Core.Ktx => 0x3a4e74a233da124b => 100
	i64 4239882675311405204, ; 92: Xamarin.Firebase.Encoders.JSON => 0x3ad716d44f44e894 => 144
	i64 4247996603072512073, ; 93: Xamarin.GooglePlayServices.Tasks => 0x3af3ea6755340049 => 164
	i64 4335356748765836238, ; 94: Xamarin.Google.Android.DataTransport.TransportBackendCct => 0x3c2a47fe48c7b3ce => 155
	i64 4337444564132831293, ; 95: SQLitePCLRaw.batteries_v2.dll => 0x3c31b2d9ae16203d => 56
	i64 4525561845656915374, ; 96: System.ServiceModel.Internals => 0x3ece06856b710dae => 175
	i64 4636684751163556186, ; 97: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 135
	i64 4637096674325028196, ; 98: SuperSocket.ClientEngine.dll => 0x405a46db5e49dd64 => 60
	i64 4702770163853758138, ; 99: Xamarin.Firebase.Components => 0x4143988c34cf0eba => 141
	i64 4782108999019072045, ; 100: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0x425d76cc43bb0a2d => 92
	i64 4794310189461587505, ; 101: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 85
	i64 4795410492532947900, ; 102: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 130
	i64 5103417709280584325, ; 103: System.Collections.Specialized => 0x46d2fb5e161b6285 => 179
	i64 5142919913060024034, ; 104: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 151
	i64 5182934613077526976, ; 105: System.Collections.Specialized.dll => 0x47ed7b91fa9009c0 => 179
	i64 5203618020066742981, ; 106: Xamarin.Essentials => 0x4836f704f0e652c5 => 138
	i64 5205316157927637098, ; 107: Xamarin.AndroidX.LocalBroadcastManager => 0x483cff7778e0c06a => 119
	i64 5286637047618374099, ; 108: OxyPlot => 0x495de8628fb689d3 => 45
	i64 5348796042099802469, ; 109: Xamarin.AndroidX.Media => 0x4a3abda9415fc165 => 120
	i64 5376510917114486089, ; 110: Xamarin.AndroidX.VectorDrawable.Animated => 0x4a9d3431719e5d49 => 133
	i64 5408338804355907810, ; 111: Xamarin.AndroidX.Transition => 0x4b0e477cea9840e2 => 132
	i64 5446034149219586269, ; 112: System.Diagnostics.Debug => 0x4b94333452e150dd => 10
	i64 5451019430259338467, ; 113: Xamarin.AndroidX.ConstraintLayout.dll => 0x4ba5e94a845c2ce3 => 98
	i64 5507995362134886206, ; 114: System.Core.dll => 0x4c705499688c873e => 69
	i64 5528247634813456972, ; 115: Plugin.LocalNotification.dll => 0x4cb847ef1773124c => 50
	i64 5650097808083101034, ; 116: System.Security.Cryptography.Algorithms.dll => 0x4e692e055d01a56a => 186
	i64 5678797808276697369, ; 117: azizapp.Android => 0x4ecf2484e1997119 => 1
	i64 5692067934154308417, ; 118: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 137
	i64 5727578611269242493, ; 119: FSharp.Core => 0x4f7c7266a3d40e7d => 24
	i64 5757522595884336624, ; 120: Xamarin.AndroidX.Concurrent.Futures.dll => 0x4fe6d44bd9f885f0 => 96
	i64 5814345312393086621, ; 121: Xamarin.AndroidX.Preference => 0x50b0b44182a5c69d => 125
	i64 5896680224035167651, ; 122: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x51d5376bfbafdda3 => 114
	i64 5984759512290286505, ; 123: System.Security.Cryptography.Primitives => 0x530e23115c33dba9 => 15
	i64 6085203216496545422, ; 124: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 152
	i64 6086316965293125504, ; 125: FormsViewGroup.dll => 0x5476f10882baef80 => 23
	i64 6092862891035488599, ; 126: Xamarin.Firebase.Measurement.Connector.dll => 0x548e32849d547157 => 148
	i64 6183170893902868313, ; 127: SQLitePCLRaw.batteries_v2 => 0x55cf092b0c9d6f59 => 56
	i64 6319713645133255417, ; 128: Xamarin.AndroidX.Lifecycle.Runtime => 0x57b42213b45b52f9 => 115
	i64 6401687960814735282, ; 129: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 113
	i64 6459596646370694080, ; 130: Microsoft.AspNetCore.JsonPatch.dll => 0x59a518eceb3ad3c0 => 33
	i64 6504860066809920875, ; 131: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 93
	i64 6548213210057960872, ; 132: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 103
	i64 6554405243736097249, ; 133: Xamarin.GooglePlayServices.Stats => 0x5af5ecd7aad901e1 => 163
	i64 6560151584539558821, ; 134: Microsoft.Extensions.Options => 0x5b0a571be53243a5 => 39
	i64 6591024623626361694, ; 135: System.Web.Services.dll => 0x5b7805f9751a1b5e => 174
	i64 6659513131007730089, ; 136: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 109
	i64 6671798237668743565, ; 137: SkiaSharp => 0x5c96fd260152998d => 52
	i64 6876862101832370452, ; 138: System.Xml.Linq => 0x5f6f85a57d108914 => 83
	i64 6878582369430612696, ; 139: Xamarin.Google.Android.DataTransport.TransportRuntime.dll => 0x5f75a238802d2ad8 => 156
	i64 6894844156784520562, ; 140: System.Numerics.Vectors => 0x5faf683aead1ad72 => 77
	i64 6903020194447737924, ; 141: FSharp.Core.resources => 0x5fcc744b0767c444 => 0
	i64 6975328107116786489, ; 142: Xamarin.Firebase.Annotations => 0x60cd57f4e07e7339 => 139
	i64 7026608356547306326, ; 143: Syncfusion.Core.XForms.dll => 0x618387125bcb2356 => 62
	i64 7036436454368433159, ; 144: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x61a671acb33d5407 => 111
	i64 7103753931438454322, ; 145: Xamarin.AndroidX.Interpolator.dll => 0x62959a90372c7632 => 108
	i64 7141577505875122296, ; 146: System.Runtime.InteropServices.WindowsRuntime.dll => 0x631bfae7659b5878 => 13
	i64 7259815123866229707, ; 147: FSharp.Core.resources.dll => 0x64c00b64190e1bcb => 0
	i64 7270811800166795866, ; 148: System.Linq => 0x64e71ccf51a90a5a => 185
	i64 7338192458477945005, ; 149: System.Reflection => 0x65d67f295d0740ad => 184
	i64 7385250113861300937, ; 150: Xamarin.Firebase.Iid.Interop.dll => 0x667dadd98e1db2c9 => 145
	i64 7476537270401454554, ; 151: Xamarin.Firebase.Encoders.JSON.dll => 0x67c1ff08f83f51da => 144
	i64 7488575175965059935, ; 152: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 83
	i64 7576191739629449958, ; 153: Microsoft.AspNet.SignalR.Client => 0x69240a3f2edcb2e6 => 30
	i64 7602111570124318452, ; 154: System.Reactive => 0x698020320025a6f4 => 78
	i64 7608914158415257261, ; 155: DropdownMenu.dll => 0x69984b1d02c81ead => 18
	i64 7635363394907363464, ; 156: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 150
	i64 7637365915383206639, ; 157: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 138
	i64 7654504624184590948, ; 158: System.Net.Http => 0x6a3a4366801b8264 => 74
	i64 7735176074855944702, ; 159: Microsoft.CSharp => 0x6b58dda848e391fe => 34
	i64 7735352534559001595, ; 160: Xamarin.Kotlin.StdLib.dll => 0x6b597e2582ce8bfb => 168
	i64 7820441508502274321, ; 161: System.Data => 0x6c87ca1e14ff8111 => 12
	i64 7836164640616011524, ; 162: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 88
	i64 7897055078423471010, ; 163: Fabulous.XamarinForms.OxyPlot.dll => 0x6d97f9c0e12023a2 => 21
	i64 7904570928025870493, ; 164: Xamarin.Firebase.Installations => 0x6db2ad60fadca09d => 146
	i64 7927939710195668715, ; 165: SkiaSharp.Views.Android.dll => 0x6e05b32992ed16eb => 53
	i64 7940488133782528123, ; 166: Xamarin.GooglePlayServices.CloudMessaging => 0x6e3247e31d4fe07b => 161
	i64 7969431548154767168, ; 167: Xamarin.Firebase.Installations.dll => 0x6e991bc4e98e6740 => 146
	i64 8044118961405839122, ; 168: System.ComponentModel.Composition => 0x6fa2739369944712 => 172
	i64 8064050204834738623, ; 169: System.Collections.dll => 0x6fe942efa61731bf => 5
	i64 8083354569033831015, ; 170: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 112
	i64 8087206902342787202, ; 171: System.Diagnostics.DiagnosticSource => 0x703b87d46f3aa082 => 70
	i64 8103644804370223335, ; 172: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 169
	i64 8167236081217502503, ; 173: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 25
	i64 8185542183669246576, ; 174: System.Collections => 0x7198e33f4794aa70 => 5
	i64 8187102936927221770, ; 175: SkiaSharp.Views.Forms => 0x719e6ebe771ab80a => 54
	i64 8290740647658429042, ; 176: System.Runtime.Extensions => 0x730ea0b15c929a72 => 178
	i64 8377847505162989171, ; 177: OxyPlot.Xamarin.Forms => 0x744417eb0fa1ee73 => 47
	i64 8398329775253868912, ; 178: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x748cdc6f3097d170 => 97
	i64 8400357532724379117, ; 179: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 124
	i64 8465511506719290632, ; 180: Xamarin.Firebase.Messaging.dll => 0x757b89dcf7fc3508 => 149
	i64 8601935802264776013, ; 181: Xamarin.AndroidX.Transition.dll => 0x7760370982b4ed4d => 132
	i64 8626175481042262068, ; 182: Java.Interop => 0x77b654e585b55834 => 25
	i64 8638972117149407195, ; 183: Microsoft.CSharp.dll => 0x77e3cb5e8b31d7db => 34
	i64 8639588376636138208, ; 184: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 123
	i64 8684531736582871431, ; 185: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 171
	i64 8702320156596882678, ; 186: Firebase.dll => 0x78c4da1357adccf6 => 22
	i64 8711110225871910191, ; 187: DropdownMenu => 0x78e41498d45e352f => 18
	i64 8725526185868997716, ; 188: System.Diagnostics.DiagnosticSource.dll => 0x79174bd613173454 => 70
	i64 8844506025403580595, ; 189: Plugin.FirebasePushNotification => 0x7abdff5eb1fb80b3 => 49
	i64 8853378295825400934, ; 190: Xamarin.Kotlin.StdLib.Common.dll => 0x7add84a720d38466 => 167
	i64 9034105039140296321, ; 191: Syncfusion.SfChart.XForms => 0x7d5f96ab19861681 => 67
	i64 9057635389615298436, ; 192: LiteDB => 0x7db32f65bf06d784 => 26
	i64 9083778504339266700, ; 193: OxyPlot.Xamarin.Android.dll => 0x7e10106bf9789c8c => 46
	i64 9153841762054881999, ; 194: Fabulous.XamarinForms.dll => 0x7f08fa955d6ac2cf => 20
	i64 9296667808972889535, ; 195: LiteDB.dll => 0x8104661dcca35dbf => 26
	i64 9312692141327339315, ; 196: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 137
	i64 9324707631942237306, ; 197: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 89
	i64 9584643793929893533, ; 198: System.IO.dll => 0x85037ebfbbd7f69d => 181
	i64 9659729154652888475, ; 199: System.Text.RegularExpressions => 0x860e407c9991dd9b => 187
	i64 9662334977499516867, ; 200: System.Numerics.dll => 0x8617827802b0cfc3 => 76
	i64 9678050649315576968, ; 201: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 99
	i64 9704315356731487263, ; 202: Plugin.FirebasePushNotification.dll => 0x86aca766ba59341f => 49
	i64 9711637524876806384, ; 203: Xamarin.AndroidX.Media.dll => 0x86c6aadfd9a2c8f0 => 120
	i64 9774216967140627647, ; 204: Xamarin.Firebase.Datatransport.dll => 0x87a4fe8bac0354bf => 142
	i64 9796610708422913120, ; 205: Xamarin.Firebase.Iid.Interop => 0x87f48d88de55ec60 => 145
	i64 9808709177481450983, ; 206: Mono.Android.dll => 0x881f890734e555e7 => 42
	i64 9825649861376906464, ; 207: Xamarin.AndroidX.Concurrent.Futures => 0x885bb87d8abc94e0 => 96
	i64 9834056768316610435, ; 208: System.Transactions.dll => 0x8879968718899783 => 173
	i64 9875200773399460291, ; 209: Xamarin.GooglePlayServices.Base.dll => 0x890bc2c8482339c3 => 159
	i64 9998632235833408227, ; 210: Mono.Security => 0x8ac2470b209ebae3 => 182
	i64 10038780035334861115, ; 211: System.Net.Http.dll => 0x8b50e941206af13b => 74
	i64 10144742755892837524, ; 212: Firebase => 0x8cc95dc98eb5bc94 => 22
	i64 10229024438826829339, ; 213: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 103
	i64 10243523786148452761, ; 214: Microsoft.AspNetCore.Http.Abstractions => 0x8e284e9c69a49999 => 31
	i64 10321854143672141184, ; 215: Xamarin.Jetbrains.Annotations.dll => 0x8f3e97a7f8f8c580 => 166
	i64 10352330178246763130, ; 216: Xamarin.Firebase.Measurement.Connector => 0x8faadd72b7f4627a => 148
	i64 10360651442923773544, ; 217: System.Text.Encoding => 0x8fc86d98211c1e68 => 4
	i64 10376576884623852283, ; 218: Xamarin.AndroidX.Tracing.Tracing => 0x900101b2f888c2fb => 131
	i64 10390244938473477758, ; 219: System.Net.WebSockets.WebSocketProtocol.dll => 0x903190b8bf03167e => 75
	i64 10430153318873392755, ; 220: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 101
	i64 10714184849103829812, ; 221: System.Runtime.Extensions.dll => 0x94b06e5aa4b4bb34 => 178
	i64 10785150219063592792, ; 222: System.Net.Primitives => 0x95ac8cfb68830758 => 7
	i64 10847732767863316357, ; 223: Xamarin.AndroidX.Arch.Core.Common => 0x968ae37a86db9f85 => 90
	i64 11002576679268595294, ; 224: Microsoft.Extensions.Logging.Abstractions => 0x98b1013215cd365e => 37
	i64 11023048688141570732, ; 225: System.Core => 0x98f9bc61168392ac => 69
	i64 11037814507248023548, ; 226: System.Xml => 0x992e31d0412bf7fc => 82
	i64 11050168729868392624, ; 227: Microsoft.AspNetCore.Http.Features => 0x995a15e9dbef58b0 => 32
	i64 11162124722117608902, ; 228: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 136
	i64 11171845786728836392, ; 229: Xamarin.GooglePlayServices.CloudMessaging.dll => 0x9b0a5e8d536aad28 => 161
	i64 11226290749488709958, ; 230: Microsoft.Extensions.Options.dll => 0x9bcbcbf50c874146 => 39
	i64 11329751333533450475, ; 231: System.Threading.Timer.dll => 0x9d3b5ccf6cc500eb => 14
	i64 11336891506707244397, ; 232: Xamarin.Firebase.Datatransport => 0x9d54bac28a6da56d => 142
	i64 11340910727871153756, ; 233: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 102
	i64 11376351552967644903, ; 234: Xamarin.Firebase.Annotations.dll => 0x9de0eb76829996e7 => 139
	i64 11392833485892708388, ; 235: Xamarin.AndroidX.Print.dll => 0x9e1b79b18fcf6824 => 126
	i64 11513602507638267977, ; 236: System.IO.Pipelines.dll => 0x9fc8887aa0d36049 => 72
	i64 11529969570048099689, ; 237: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 136
	i64 11530571088791430846, ; 238: Microsoft.Extensions.Logging => 0xa004d1504ccd66be => 38
	i64 11578238080964724296, ; 239: Xamarin.AndroidX.Legacy.Support.V4 => 0xa0ae2a30c4cd8648 => 111
	i64 11580057168383206117, ; 240: Xamarin.AndroidX.Annotation => 0xa0b4a0a4103262e5 => 86
	i64 11597940890313164233, ; 241: netstandard => 0xa0f429ca8d1805c9 => 2
	i64 11672361001936329215, ; 242: Xamarin.AndroidX.Interpolator => 0xa1fc8e7d0a8999ff => 108
	i64 11739066727115742305, ; 243: SQLite-net.dll => 0xa2e98afdf8575c61 => 55
	i64 11743665907891708234, ; 244: System.Threading.Tasks => 0xa2f9e1ec30c0214a => 9
	i64 11806260347154423189, ; 245: SQLite-net => 0xa3d8433bc5eb5d95 => 55
	i64 12102847907131387746, ; 246: System.Buffers => 0xa7f5f40c43256f62 => 68
	i64 12137774235383566651, ; 247: Xamarin.AndroidX.VectorDrawable => 0xa872095bbfed113b => 134
	i64 12279246230491828964, ; 248: SQLitePCLRaw.provider.e_sqlite3.dll => 0xaa68a5636e0512e4 => 59
	i64 12313367145828839434, ; 249: System.IO.Pipelines => 0xaae1de2e1c17f00a => 72
	i64 12346958216201575315, ; 250: Xamarin.JavaX.Inject.dll => 0xab593514a5491b93 => 165
	i64 12418091070531475652, ; 251: Fabulous.dll => 0xac55ec08e77a98c4 => 19
	i64 12451044538927396471, ; 252: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 107
	i64 12466513435562512481, ; 253: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 118
	i64 12487638416075308985, ; 254: Xamarin.AndroidX.DocumentFile.dll => 0xad4d00fa21b0bfb9 => 104
	i64 12538491095302438457, ; 255: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 94
	i64 12550732019250633519, ; 256: System.IO.Compression => 0xae2d28465e8e1b2f => 170
	i64 12700543734426720211, ; 257: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 95
	i64 12708238894395270091, ; 258: System.IO => 0xb05cbbf17d3ba3cb => 181
	i64 12757172224776395555, ; 259: azizapp.Android.dll => 0xb10a948c4c46db23 => 1
	i64 12843321153144804894, ; 260: Microsoft.Extensions.Primitives => 0xb23ca48abd74d61e => 40
	i64 12854524964145442905, ; 261: Xamarin.Firebase.Encoders.dll => 0xb26472594447b059 => 143
	i64 12963446364377008305, ; 262: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 11
	i64 13011563728930061243, ; 263: OxyPlot.dll => 0xb4925c45f33bbbbb => 45
	i64 13070736518021853291, ; 264: Microsoft.AspNetCore.JsonPatch => 0xb564959c856b306b => 33
	i64 13370592475155966277, ; 265: System.Runtime.Serialization => 0xb98de304062ea945 => 16
	i64 13401370062847626945, ; 266: Xamarin.AndroidX.VectorDrawable.dll => 0xb9fb3b1193964ec1 => 134
	i64 13403416310143541304, ; 267: Microcharts.Droid => 0xba02801ea6c86038 => 28
	i64 13404347523447273790, ; 268: Xamarin.AndroidX.ConstraintLayout.Core => 0xba05cf0da4f6393e => 97
	i64 13404984788036896679, ; 269: Microsoft.AspNetCore.Http.Abstractions.dll => 0xba0812a45e7447a7 => 31
	i64 13454009404024712428, ; 270: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 158
	i64 13465488254036897740, ; 271: Xamarin.Kotlin.StdLib => 0xbadf06394d106fcc => 168
	i64 13491513212026656886, ; 272: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0xbb3b7bc905569876 => 91
	i64 13492263892638604996, ; 273: SkiaSharp.Views.Forms.dll => 0xbb3e2686788d9ec4 => 54
	i64 13572454107664307259, ; 274: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 127
	i64 13622732128915678507, ; 275: Syncfusion.Core.XForms.Android => 0xbd0daab1e651e52b => 61
	i64 13647894001087880694, ; 276: System.Data.dll => 0xbd670f48cb071df6 => 12
	i64 13828521679616088467, ; 277: Xamarin.Kotlin.StdLib.Common => 0xbfe8c733724e1993 => 167
	i64 13829530607229561650, ; 278: Xamarin.Firebase.Installations.InterOp => 0xbfec5cd0b64f6b32 => 147
	i64 13849821837823696015, ; 279: Syncfusion.Expander.XForms.Android => 0xc0347394fdeddc8f => 63
	i64 13959074834287824816, ; 280: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 107
	i64 13967638549803255703, ; 281: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 151
	i64 13970307180132182141, ; 282: Syncfusion.Licensing => 0xc1e0805ccade287d => 65
	i64 14030805823765547820, ; 283: PropertyChanged.dll => 0xc2b76f8eee070b2c => 51
	i64 14124974489674258913, ; 284: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 94
	i64 14125464355221830302, ; 285: System.Threading.dll => 0xc407bafdbc707a9e => 6
	i64 14172845254133543601, ; 286: Xamarin.AndroidX.MultiDex => 0xc4b00faaed35f2b1 => 121
	i64 14261073672896646636, ; 287: Xamarin.AndroidX.Print => 0xc5e982f274ae0dec => 126
	i64 14327695147300244862, ; 288: System.Reflection.dll => 0xc6d632d338eb4d7e => 184
	i64 14327709162229390963, ; 289: System.Security.Cryptography.X509Certificates => 0xc6d63f9253cade73 => 180
	i64 14486659737292545672, ; 290: Xamarin.AndroidX.Lifecycle.LiveData => 0xc90af44707469e88 => 114
	i64 14524915121004231475, ; 291: Xamarin.JavaX.Inject => 0xc992dd58a4283b33 => 165
	i64 14536303476482288245, ; 292: Syncfusion.Expander.XForms => 0xc9bb52fec700aa75 => 64
	i64 14538127318538747197, ; 293: Syncfusion.Licensing.dll => 0xc9c1cdc518e77d3d => 65
	i64 14551742072151931844, ; 294: System.Text.Encodings.Web.dll => 0xc9f22c50f1b8fbc4 => 81
	i64 14561513370130550166, ; 295: System.Security.Cryptography.Primitives.dll => 0xca14e3428abb8d96 => 15
	i64 14644440854989303794, ; 296: Xamarin.AndroidX.LocalBroadcastManager.dll => 0xcb3b815e37daeff2 => 119
	i64 14669215534098758659, ; 297: Microsoft.Extensions.DependencyInjection.dll => 0xcb9385ceb3993c03 => 36
	i64 14678510994762383812, ; 298: Xamarin.GooglePlayServices.Location.dll => 0xcbb48bfaca7a41c4 => 162
	i64 14763643331770587208, ; 299: OxyPlot.Xamarin.Forms.dll => 0xcce2ff639cc01848 => 47
	i64 14789919016435397935, ; 300: Xamarin.Firebase.Common.dll => 0xcd4058fc2f6d352f => 140
	i64 14792063746108907174, ; 301: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 158
	i64 14809388726477333247, ; 302: Xamarin.GooglePlayServices.Stats.dll => 0xcd8584954e5b22ff => 163
	i64 14852515768018889994, ; 303: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 102
	i64 14954917835170835695, ; 304: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xcf8a8a895a82ecef => 35
	i64 14987728460634540364, ; 305: System.IO.Compression.dll => 0xcfff1ba06622494c => 170
	i64 14988210264188246988, ; 306: Xamarin.AndroidX.DocumentFile => 0xd000d1d307cddbcc => 104
	i64 15015154896917945444, ; 307: System.Net.Security.dll => 0xd0608bd33642dc64 => 8
	i64 15133485256822086103, ; 308: System.Linq.dll => 0xd204f0a9127dd9d7 => 185
	i64 15370334346939861994, ; 309: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 101
	i64 15391712275433856905, ; 310: Microsoft.Extensions.DependencyInjection.Abstractions => 0xd59a58c406411f89 => 35
	i64 15526743539506359484, ; 311: System.Text.Encoding.dll => 0xd77a12fc26de2cbc => 4
	i64 15541854775306130054, ; 312: System.Security.Cryptography.X509Certificates.dll => 0xd7afc292e8d49286 => 180
	i64 15557562860424774966, ; 313: System.Net.Sockets => 0xd7e790fe7a6dc536 => 177
	i64 15582737692548360875, ; 314: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 117
	i64 15609085926864131306, ; 315: System.dll => 0xd89e9cf3334914ea => 71
	i64 15777549416145007739, ; 316: Xamarin.AndroidX.SlidingPaneLayout.dll => 0xdaf51d99d77eb47b => 129
	i64 15810740023422282496, ; 317: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 153
	i64 15817206913877585035, ; 318: System.Threading.Tasks.dll => 0xdb8201e29086ac8b => 9
	i64 15852824340364052161, ; 319: Microsoft.AspNetCore.Http.Features.dll => 0xdc008bbee610c6c1 => 32
	i64 15930129725311349754, ; 320: Xamarin.GooglePlayServices.Tasks.dll => 0xdd1330956f12f3fa => 164
	i64 15963349826457351533, ; 321: System.Threading.Tasks.Extensions => 0xdd893616f748b56d => 183
	i64 16106398470792018018, ; 322: Syncfusion.Expander.XForms.Android.dll => 0xdf856c12e673f862 => 63
	i64 16137700272994578925, ; 323: Fabulous => 0xdff4a0e5a790f1ed => 19
	i64 16150183177059685051, ; 324: Syncfusion.SfChart.XForms.dll => 0xe020fa083e21d2bb => 67
	i64 16154507427712707110, ; 325: System => 0xe03056ea4e39aa26 => 71
	i64 16219561732052121626, ; 326: System.Net.Security => 0xe1177575db7c781a => 8
	i64 16321164108206115771, ; 327: Microsoft.Extensions.Logging.Abstractions.dll => 0xe2806c487e7b0bbb => 37
	i64 16324796876805858114, ; 328: SkiaSharp.dll => 0xe28d5444586b6342 => 52
	i64 16467346005009053642, ; 329: Xamarin.Google.Android.DataTransport.TransportApi => 0xe487c3f19e0337ca => 154
	i64 16552427520763284698, ; 330: Syncfusion.SfChart.XForms.Android => 0xe5b60921b17eccda => 66
	i64 16565028646146589191, ; 331: System.ComponentModel.Composition.dll => 0xe5e2cdc9d3bcc207 => 172
	i64 16621146507174665210, ; 332: Xamarin.AndroidX.ConstraintLayout => 0xe6aa2caf87dedbfa => 98
	i64 16677317093839702854, ; 333: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 124
	i64 16755018182064898362, ; 334: SQLitePCLRaw.core.dll => 0xe885c843c330813a => 57
	i64 16822611501064131242, ; 335: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 169
	i64 16833383113903931215, ; 336: mscorlib => 0xe99c30c1484d7f4f => 43
	i64 16866861824412579935, ; 337: System.Runtime.InteropServices.WindowsRuntime => 0xea132176ffb5785f => 13
	i64 16890310621557459193, ; 338: System.Text.RegularExpressions.dll => 0xea66700587f088f9 => 187
	i64 16917457086350843780, ; 339: SuperSocket.ClientEngine => 0xeac6e19666db5f84 => 60
	i64 16989203637347086287, ; 340: WebSocket4Net => 0xebc5c6b20cd8efcf => 84
	i64 17001062948826229159, ; 341: Microcharts.Forms.dll => 0xebefe8ad2cd7a9a7 => 29
	i64 17024911836938395553, ; 342: Xamarin.AndroidX.Annotation.Experimental.dll => 0xec44a31d250e5fa1 => 87
	i64 17031351772568316411, ; 343: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 122
	i64 17037200463775726619, ; 344: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xec704b8e0a78fc1b => 110
	i64 17093861494148505353, ; 345: FSharp.Core.dll => 0xed39987636731f09 => 24
	i64 17126545051278881272, ; 346: Microsoft.Net.Http.Headers.dll => 0xedadb5fbdb33b1f8 => 41
	i64 17211698044874985152, ; 347: OxyPlot.Xamarin.Android => 0xeedc3c2e2a0f0ec0 => 46
	i64 17434242208926550937, ; 348: Xamarin.Google.Android.DataTransport.TransportRuntime => 0xf1f2deeb1f304b99 => 156
	i64 17445007690959274801, ; 349: Fabulous.XamarinForms.OxyPlot => 0xf2191e113b95c331 => 21
	i64 17470386307322966175, ; 350: System.Threading.Timer => 0xf27347c8d0d5709f => 14
	i64 17544493274320527064, ; 351: Xamarin.AndroidX.AsyncLayoutInflater => 0xf37a8fada41aded8 => 92
	i64 17671790519499593115, ; 352: SkiaSharp.Views.Android => 0xf53ecfd92be3959b => 53
	i64 17677828421478984182, ; 353: Xamarin.Firebase.Installations.InterOp.dll => 0xf5544349c68f29f6 => 147
	i64 17685921127322830888, ; 354: System.Diagnostics.Debug.dll => 0xf571038fafa74828 => 10
	i64 17704177640604968747, ; 355: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 118
	i64 17710060891934109755, ; 356: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 116
	i64 17777860260071588075, ; 357: System.Runtime.Numerics.dll => 0xf6b7a5b72419c0eb => 176
	i64 17838668724098252521, ; 358: System.Buffers.dll => 0xf78faeb0f5bf3ee9 => 68
	i64 17882897186074144999, ; 359: FormsViewGroup => 0xf82cd03e3ac830e7 => 23
	i64 17891337867145587222, ; 360: Xamarin.Jetbrains.Annotations => 0xf84accff6fb52a16 => 166
	i64 17892495832318972303, ; 361: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 153
	i64 17911643751311784505, ; 362: Microsoft.Net.Http.Headers => 0xf892f1178448ba39 => 41
	i64 17928294245072900555, ; 363: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 171
	i64 17945795017270165205, ; 364: Xamarin.Google.Android.DataTransport.TransportApi.dll => 0xf90c457cc05cfed5 => 154
	i64 17956840076609788800, ; 365: OxyPlot.Xamarin.Forms.Platform.Android.dll => 0xf93382e906d31b80 => 48
	i64 17986907704309214542, ; 366: Xamarin.GooglePlayServices.Basement.dll => 0xf99e554223166d4e => 160
	i64 18025913125965088385, ; 367: System.Threading => 0xfa28e87b91334681 => 6
	i64 18116111925905154859, ; 368: Xamarin.AndroidX.Arch.Core.Runtime => 0xfb695bd036cb632b => 91
	i64 18121036031235206392, ; 369: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 122
	i64 18129453464017766560, ; 370: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 175
	i64 18239004110448304878, ; 371: WebSocket4Net.dll => 0xfd1df59aa42922ee => 84
	i64 18305135509493619199, ; 372: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 123
	i64 18337470502355292274, ; 373: Xamarin.Firebase.Messaging => 0xfe7bc8440c175072 => 149
	i64 18370042311372477656, ; 374: SQLitePCLRaw.lib.e_sqlite3.android.dll => 0xfeef80274e4094d8 => 58
	i64 18380184030268848184 ; 375: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 135
], align 16
@assembly_image_cache_indices = local_unnamed_addr constant [376 x i32] [
	i32 106, i32 50, i32 40, i32 42, i32 28, i32 95, i32 128, i32 129, ; 0..7
	i32 100, i32 162, i32 78, i32 48, i32 115, i32 159, i32 11, i32 109, ; 8..15
	i32 58, i32 105, i32 29, i32 173, i32 27, i32 152, i32 182, i32 157, ; 16..23
	i32 64, i32 57, i32 20, i32 90, i32 3, i32 16, i32 141, i32 7, ; 24..31
	i32 59, i32 88, i32 117, i32 110, i32 75, i32 44, i32 73, i32 89, ; 32..39
	i32 128, i32 155, i32 86, i32 186, i32 116, i32 183, i32 62, i32 17, ; 40..47
	i32 44, i32 30, i32 121, i32 51, i32 93, i32 105, i32 174, i32 113, ; 48..55
	i32 17, i32 81, i32 79, i32 27, i32 61, i32 99, i32 133, i32 80, ; 56..63
	i32 85, i32 82, i32 43, i32 36, i32 125, i32 79, i32 150, i32 157, ; 64..71
	i32 3, i32 143, i32 66, i32 112, i32 87, i32 77, i32 176, i32 177, ; 72..79
	i32 140, i32 160, i32 131, i32 130, i32 76, i32 80, i32 2, i32 127, ; 80..87
	i32 106, i32 38, i32 73, i32 100, i32 144, i32 164, i32 155, i32 56, ; 88..95
	i32 175, i32 135, i32 60, i32 141, i32 92, i32 85, i32 130, i32 179, ; 96..103
	i32 151, i32 179, i32 138, i32 119, i32 45, i32 120, i32 133, i32 132, ; 104..111
	i32 10, i32 98, i32 69, i32 50, i32 186, i32 1, i32 137, i32 24, ; 112..119
	i32 96, i32 125, i32 114, i32 15, i32 152, i32 23, i32 148, i32 56, ; 120..127
	i32 115, i32 113, i32 33, i32 93, i32 103, i32 163, i32 39, i32 174, ; 128..135
	i32 109, i32 52, i32 83, i32 156, i32 77, i32 0, i32 139, i32 62, ; 136..143
	i32 111, i32 108, i32 13, i32 0, i32 185, i32 184, i32 145, i32 144, ; 144..151
	i32 83, i32 30, i32 78, i32 18, i32 150, i32 138, i32 74, i32 34, ; 152..159
	i32 168, i32 12, i32 88, i32 21, i32 146, i32 53, i32 161, i32 146, ; 160..167
	i32 172, i32 5, i32 112, i32 70, i32 169, i32 25, i32 5, i32 54, ; 168..175
	i32 178, i32 47, i32 97, i32 124, i32 149, i32 132, i32 25, i32 34, ; 176..183
	i32 123, i32 171, i32 22, i32 18, i32 70, i32 49, i32 167, i32 67, ; 184..191
	i32 26, i32 46, i32 20, i32 26, i32 137, i32 89, i32 181, i32 187, ; 192..199
	i32 76, i32 99, i32 49, i32 120, i32 142, i32 145, i32 42, i32 96, ; 200..207
	i32 173, i32 159, i32 182, i32 74, i32 22, i32 103, i32 31, i32 166, ; 208..215
	i32 148, i32 4, i32 131, i32 75, i32 101, i32 178, i32 7, i32 90, ; 216..223
	i32 37, i32 69, i32 82, i32 32, i32 136, i32 161, i32 39, i32 14, ; 224..231
	i32 142, i32 102, i32 139, i32 126, i32 72, i32 136, i32 38, i32 111, ; 232..239
	i32 86, i32 2, i32 108, i32 55, i32 9, i32 55, i32 68, i32 134, ; 240..247
	i32 59, i32 72, i32 165, i32 19, i32 107, i32 118, i32 104, i32 94, ; 248..255
	i32 170, i32 95, i32 181, i32 1, i32 40, i32 143, i32 11, i32 45, ; 256..263
	i32 33, i32 16, i32 134, i32 28, i32 97, i32 31, i32 158, i32 168, ; 264..271
	i32 91, i32 54, i32 127, i32 61, i32 12, i32 167, i32 147, i32 63, ; 272..279
	i32 107, i32 151, i32 65, i32 51, i32 94, i32 6, i32 121, i32 126, ; 280..287
	i32 184, i32 180, i32 114, i32 165, i32 64, i32 65, i32 81, i32 15, ; 288..295
	i32 119, i32 36, i32 162, i32 47, i32 140, i32 158, i32 163, i32 102, ; 296..303
	i32 35, i32 170, i32 104, i32 8, i32 185, i32 101, i32 35, i32 4, ; 304..311
	i32 180, i32 177, i32 117, i32 71, i32 129, i32 153, i32 9, i32 32, ; 312..319
	i32 164, i32 183, i32 63, i32 19, i32 67, i32 71, i32 8, i32 37, ; 320..327
	i32 52, i32 154, i32 66, i32 172, i32 98, i32 124, i32 57, i32 169, ; 328..335
	i32 43, i32 13, i32 187, i32 60, i32 84, i32 29, i32 87, i32 122, ; 336..343
	i32 110, i32 24, i32 41, i32 46, i32 156, i32 21, i32 14, i32 92, ; 344..351
	i32 53, i32 147, i32 10, i32 118, i32 116, i32 176, i32 68, i32 23, ; 352..359
	i32 166, i32 153, i32 41, i32 171, i32 154, i32 48, i32 160, i32 6, ; 360..367
	i32 91, i32 122, i32 175, i32 84, i32 123, i32 149, i32 58, i32 135 ; 376..375
], align 16

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 8; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 8

; Function attributes: "frame-pointer"="none" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 8
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 8
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 16; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="none" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="none" "target-cpu"="x86-64" "target-features"="+cx16,+cx8,+fxsr,+mmx,+popcnt,+sse,+sse2,+sse3,+sse4.1,+sse4.2,+ssse3,+x87" "tune-cpu"="generic" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1}
!llvm.ident = !{!2}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}

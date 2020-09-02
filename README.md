# UniActionWithLogExtensionMethods

```cs
using Kogane;
using System;
using UnityEngine;

public sealed class Example : MonoBehaviour
{
    private void Start()
    {
#if ENABLE_RELEASE
        // リリースビルドの時はログ出力を無効化
        ActionWithLogExtensionMethods.OnStartLog      = null;
        ActionWithLogExtensionMethods.OnFinishLog     = null;
        ActionWithLogExtensionMethods.OnStartTimeLog  = null;
        ActionWithLogExtensionMethods.OnFinishTimeLog = null;
#else
        ActionWithLogExtensionMethods.OnStartLog      = message => Debug.Log( $"{message} 開始" );
        ActionWithLogExtensionMethods.OnFinishLog     = message => Debug.Log( $"{message} 終了" );
        ActionWithLogExtensionMethods.OnStartTimeLog  = message => Debug.Log( $"{message} 開始" );
        ActionWithLogExtensionMethods.OnFinishTimeLog = ( message, elapsed ) => Debug.Log( $"{message} 終了 {elapsed.TotalSeconds} 秒" );
#endif

        Run
        ( 
            callback0: () => Debug.Log( "" ),
            callback1: i1 => Debug.Log( i1 ),
            callback2: ( i1, i2 ) => Debug.Log( $"{i1}{i2}" ),
            callback3: ( i1, i2 ,i3 ) => Debug.Log( $"{i1}{i2}{i3}" ),
            callback4: ( i1, i2, i3, i4 ) => Debug.Log( $"{i1}{i2}{i3}{i4}" )
        );
    }

    private void Run
    (
        Action                     callback0,
        Action<int>                callback1,
        Action<int, int>           callback2,
        Action<int, int, int>      callback3,
        Action<int, int, int, int> callback4
    )
    {
        callback0.WithLog( "フシギダネ" );
        callback1.WithLog( 1, "フシギソウ" );
        callback2.WithLog( 1, 2, "フシギバナ" );
        callback3.WithLog( 1, 2, 3, "ヒトカゲ" );
        callback4.WithLog( 1, 2, 3, 4, "リザード" );

        callback0.WithTimeLog( "リザードン" );
        callback1.WithTimeLog( 1, "ゼニガメ" );
        callback2.WithTimeLog( 1, 2, "カメール" );
        callback3.WithTimeLog( 1, 2, 3, "カメックス" );
        callback4.WithTimeLog( 1, 2, 3, 4, "キャタピー" );
    }
}
```

![2020-09-03_084659](https://user-images.githubusercontent.com/6134875/92048224-1c275700-edc2-11ea-88a2-fc268c1b34da.png)

using System;
using UnityEngine;

namespace Kogane
{
	public static class ActionWithLogExtensionMethods
	{
		//================================================================================
		// デリゲート(static)
		//================================================================================
		/// <summary>
		/// WithLog 関数で処理の開始時に呼び出されます
		/// </summary>
		public static Action<string> OnStartLog { get; set; } = message => Debug.Log( $"{message} 開始" );

		/// <summary>
		/// WithLog 関数で処理の終了時に呼び出されます
		/// </summary>
		public static Action<string> OnFinishLog { get; set; } = message => Debug.Log( $"{message} 終了" );

		/// <summary>
		/// WithTimeLog 関数で処理の開始時に呼び出されます
		/// </summary>
		public static Action<string> OnStartTimeLog { get; set; } = message => Debug.Log( $"{message} 開始" );

		/// <summary>
		/// WithTimeLog 関数で処理の終了時に呼び出されます
		/// </summary>
		public static Action<string, TimeSpan> OnFinishTimeLog { get; set; } = ( message, elapsed ) => Debug.Log( $"{message} 終了 {elapsed.TotalSeconds} 秒" );

		//================================================================================
		// 関数(static)
		//================================================================================
		/// <summary>
		/// Action デリゲートの実行前と実行後にログを出力します
		/// </summary>
		public static void WithLog
		(
			this Action self,
			string      message
		)
		{
			OnStartLog?.Invoke( message );
			self();
			OnFinishLog?.Invoke( message );
		}

		/// <summary>
		/// Action デリゲートの実行前と実行後にログを出力します
		/// </summary>
		public static void WithLog<T>
		(
			this Action<T> self,
			T              arg,
			string         message
		)
		{
			OnStartLog?.Invoke( message );
			self( arg );
			OnFinishLog?.Invoke( message );
		}

		/// <summary>
		/// Action デリゲートの実行前と実行後にログを出力します
		/// </summary>
		public static void WithLog<T1, T2>
		(
			this Action<T1, T2> self,
			T1                  arg1,
			T2                  arg2,
			string              message
		)
		{
			OnStartLog?.Invoke( message );
			self( arg1, arg2 );
			OnFinishLog?.Invoke( message );
		}

		/// <summary>
		/// Action デリゲートの実行前と実行後にログを出力します
		/// </summary>
		public static void WithLog<T1, T2, T3>
		(
			this Action<T1, T2, T3> self,
			T1                      arg1,
			T2                      arg2,
			T3                      arg3,
			string                  message
		)
		{
			OnStartLog?.Invoke( message );
			self( arg1, arg2, arg3 );
			OnFinishLog?.Invoke( message );
		}

		/// <summary>
		/// Action デリゲートの実行前と実行後にログを出力します
		/// </summary>
		public static void WithLog<T1, T2, T3, T4>
		(
			this Action<T1, T2, T3, T4> self,
			T1                          arg1,
			T2                          arg2,
			T3                          arg3,
			T4                          arg4,
			string                      message
		)
		{
			OnStartLog?.Invoke( message );
			self( arg1, arg2, arg3, arg4 );
			OnFinishLog?.Invoke( message );
		}

		/// <summary>
		/// Action デリゲートの実行前と実行後に経過時間付きのログを出力します
		/// </summary>
		public static void WithTimeLog
		(
			this Action self,
			string      message
		)
		{
			OnStartTimeLog?.Invoke( message );
			var now = DateTime.Now;
			self();
			OnFinishTimeLog?.Invoke( message, DateTime.Now - now );
		}

		/// <summary>
		/// Action デリゲートの実行前と実行後に経過時間付きのログを出力します
		/// </summary>
		public static void WithTimeLog<T>
		(
			this Action<T> self,
			T              arg,
			string         message
		)
		{
			OnStartTimeLog?.Invoke( message );
			var now = DateTime.Now;
			self( arg );
			OnFinishTimeLog?.Invoke( message, DateTime.Now - now );
		}

		/// <summary>
		/// Action デリゲートの実行前と実行後に経過時間付きのログを出力します
		/// </summary>
		public static void WithTimeLog<T1, T2>
		(
			this Action<T1, T2> self,
			T1                  arg1,
			T2                  arg2,
			string              message
		)
		{
			OnStartTimeLog?.Invoke( message );
			var now = DateTime.Now;
			self( arg1, arg2 );
			OnFinishTimeLog?.Invoke( message, DateTime.Now - now );
		}

		/// <summary>
		/// Action デリゲートの実行前と実行後に経過時間付きのログを出力します
		/// </summary>
		public static void WithTimeLog<T1, T2, T3>
		(
			this Action<T1, T2, T3> self,
			T1                      arg1,
			T2                      arg2,
			T3                      arg3,
			string                  message
		)
		{
			OnStartTimeLog?.Invoke( message );
			var now = DateTime.Now;
			self( arg1, arg2, arg3 );
			OnFinishTimeLog?.Invoke( message, DateTime.Now - now );
		}

		/// <summary>
		/// Action デリゲートの実行前と実行後に経過時間付きのログを出力します
		/// </summary>
		public static void WithTimeLog<T1, T2, T3, T4>
		(
			this Action<T1, T2, T3, T4> self,
			T1                          arg1,
			T2                          arg2,
			T3                          arg3,
			T4                          arg4,
			string                      message
		)
		{
			OnStartTimeLog?.Invoke( message );
			var now = DateTime.Now;
			self( arg1, arg2, arg3, arg4 );
			OnFinishTimeLog?.Invoke( message, DateTime.Now - now );
		}
	}
}
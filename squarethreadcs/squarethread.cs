using System.Diagnostics;

namespace squarethread
{
	class Program
	{
		static readonly object tlock = new();
		private static long cycles;
		private static long matches;
		private static long tosolve;
		private static long tocycle;
		private static long gnumthreads;
		private static Stopwatch s1 = Stopwatch.StartNew();
		static void Main()
		{
		begin:
			matches = 0;
			cycles = 0;
			int start = 1;

			Console.Write("Threads: ");
			int numthreads = Convert.ToInt32(Console.ReadLine());
			if (numthreads == 0) { return; }
			Console.Write("Target: ");
			int target = Convert.ToInt32(Console.ReadLine());
			if (target == 0) { return; }
			if (numthreads > target) { return; }
			int step = numthreads;

			gnumthreads = numthreads;
			tocycle = (long)Math.Pow(target, 9);

			Thread mainThread = Thread.CurrentThread;
			mainThread.Name = "Main Thread";

			s1.Restart();

			Thread[] threads = new Thread[numthreads];

			int t = target + 1;
			tosolve = (t % 12) switch
			{
				0 or 2 or 6 or 8 => ((t * t * t) - 16 * t * t + 76 * t - 96) / 6,
				1 => ((t * t * t) - 16 * t * t + 73 * t - 58) / 6,
				3 or 11 => ((t * t * t) - 16 * t * t + 73 * t - 102) / 6,
				4 or 10 => ((t * t * t) - 16 * t * t + 76 * t - 112) / 6,
				5 or 9 => ((t * t * t) - 16 * t * t + 73 * t - 90) / 6,
				7 => ((t * t * t) - 16 * t * t + 73 * t - 70) / 6,
				_ => 0,
			};

			for (int i = 0; i < numthreads; i++)
			{
				threads[i] = new Thread(new ThreadStart(() => CountUp(target, step, start)));
				threads[i].Name = Convert.ToString(i);
				threads[i].Start();
			}

			bool working = true;
			while (working)
			{
				foreach (Thread thread in threads)
				{
					if (thread.IsAlive)
					{
						working = true;
						break;
					}
					if (!thread.IsAlive) { working = false; }
				}
			}

			s1.Stop();

			long frequency = Stopwatch.Frequency;
			Console.WriteLine("\n[" + numthreads + "] threads finished (0-" + target + ")");
			Console.WriteLine("\nTimer ticks p/s: " + frequency.ToString("N0"));
			long nanosecPerTick = (1000L * 1000L * 1000L) / frequency;
			Console.WriteLine("Timer accuracy within " + nanosecPerTick.ToString("N0") + " nanoseconds\n");
			var totalmins = (s1.Elapsed.TotalMilliseconds / 1000) / 60;
			
			Console.WriteLine("Cycles     : " + cycles.ToString("N0"));
			Console.WriteLine("Speed      : " + (cycles / (s1.Elapsed.TotalMilliseconds / 1000)).ToString("N0") + " cps");
			Console.WriteLine("Matches    : " + matches.ToString("N0") + " / " + tosolve.ToString("N0"));
			Console.WriteLine("Total time : " + ((double)(s1.Elapsed.TotalMilliseconds / 1000)).ToString("0.000s") + " ("
				+ totalmins.ToString("0.0m") + ")\n");
			
			goto begin;
		}
		public static void CountUp(int iTarget, int iStep, int iStart)
		{
			long cps = 0;
			long tcycles = 0;
			long tmatches = 0;
			long a = iStart + Convert.ToInt64(Thread.CurrentThread.Name);
			long b = iStart;
			long c = iStart;
			long d = iStart;
			long e = iStart;
			long f = iStart;
			long g = iStart;
			long h = iStart;
			long i = iStart;
		sloop:
			if (a == b) { goto notequal; }
			if (a + b + c != d + e + f) { goto notequal; }
			if (a + b + c != g + h + i) { goto notequal; }
			if (a + b + c != a + d + g) { goto notequal; }
			if (a + b + c != b + e + h) { goto notequal; }
			if (a + b + c != c + f + i) { goto notequal; }
			if (a + b + c != a + e + i) { goto notequal; }
			if (a + b + c != c + e + g) { goto notequal; }
			// compare (a) with cells
			if (a == b) { goto notequal; }
			if (a == c) { goto notequal; }
			if (a == d) { goto notequal; }
			if (a == e) { goto notequal; }
			if (a == f) { goto notequal; }
			if (a == g) { goto notequal; }
			if (a == h) { goto notequal; }
			if (a == i) { goto notequal; }
			// compare (b) with cells
			if (b == c) { goto notequal; }
			if (b == d) { goto notequal; }
			if (b == e) { goto notequal; }
			if (b == f) { goto notequal; }
			if (b == g) { goto notequal; }
			if (b == h) { goto notequal; }
			if (b == i) { goto notequal; }
			// compare (c) with cells
			if (c == d) { goto notequal; }
			if (c == e) { goto notequal; }
			if (c == f) { goto notequal; }
			if (c == g) { goto notequal; }
			if (c == h) { goto notequal; }
			if (c == i) { goto notequal; }
			// compare (d) with cells
			if (d == e) { goto notequal; }
			if (d == f) { goto notequal; }
			if (d == g) { goto notequal; }
			if (d == h) { goto notequal; }
			if (d == i) { goto notequal; }
			// compare (e) with cells
			if (e == f) { goto notequal; }
			if (e == g) { goto notequal; }
			if (e == h) { goto notequal; }
			if (e == i) { goto notequal; }
			// compare (f) with cells
			if (f == g) { goto notequal; }
			if (f == h) { goto notequal; }
			if (f == i) { goto notequal; }
			// compare (g) with cells
			if (g == h) { goto notequal; }
			if (g == i) { goto notequal; }
			// compare (h) with cells
			if (h == i) { goto notequal; }
			tmatches++;

			Monitor.Enter(tlock);
			try
			{
				matches += 1;
				int percentComplete = (int)(0.5f + ((100f * matches) / tosolve));
				if (percentComplete < 101)
				{
					Console.WriteLine(" Solved " + matches.ToString() + " of " + tosolve.ToString() + " | n=" + (a + b + c)
						+ " | tar=" + iTarget.ToString() + " | thr=" + gnumthreads.ToString());
					string pleft = new string((char)35, percentComplete / 2);
					string pright = new string((char)45, 50 - (percentComplete / 2));
					Console.WriteLine("[" + pleft + pright + "] " + percentComplete.ToString() + "% \n");

					try
					{
						cps = (tcycles / (long)(s1.Elapsed.TotalMilliseconds / 1000));

						var secondsleft = ((tocycle / gnumthreads) - tcycles) / cps;
						cps = cps * gnumthreads;
						var minsleft = secondsleft / 60;
						var minselapsed = (double)(s1.Elapsed.TotalMilliseconds / 1000) / 60;
						Console.WriteLine("Cycles p/s     : " + cps.ToString("N0"));
						Console.WriteLine("Time elapsed   : " + ((int)(s1.Elapsed.TotalMilliseconds / 1000)).ToString("0s")
							+ " (" + minselapsed.ToString("0m") + ")");
						Console.WriteLine("Time remaining : " + secondsleft.ToString("0s") + " (" + minsleft.ToString("0m") + ") \n");
					}
					catch
					{
						Console.WriteLine("Error: cycles too fast");
					}
				}
			}
			finally { Monitor.Exit(tlock); }

		notequal:
			tcycles += 1;

			a += iStep;
			if (a <= iTarget) { goto sloop; }
			a = (a % iStep) + 1;

			b += 1;
			if (b <= iTarget) { goto sloop; }
			b = iStart;

			c += 1;
			if (c <= iTarget) { goto sloop; }
			c = iStart;

			d += 1;
			if (d <= iTarget) { goto sloop; }
			d = iStart;

			e += 1;
			if (e <= iTarget) { goto sloop; }
			e = iStart;

			f += 1;
			if (f <= iTarget) { goto sloop; }
			f = iStart;

			g += 1;
			if (g <= iTarget) { goto sloop; }
			g = iStart;

			h += 1;
			if (h <= iTarget) { goto sloop; }
			h = iStart;

			i += 1;
			if (i <= iTarget) { goto sloop; }

			Monitor.Enter(tlock);
			try
			{
				cycles += tcycles;
				//matches += tmatches;
			}
			finally { Monitor.Exit(tlock); }

			Console.WriteLine("[" + Thread.CurrentThread.Name + "] : " + tcycles.ToString("N0") + " cycles");
			return;
		}
	}
}
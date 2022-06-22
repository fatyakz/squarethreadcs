using System.Diagnostics;

namespace squarethread
{
	class Program
	{
		static readonly object tlock = new();
		private static long cycles;
		private static long matches;

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

			Thread mainThread = Thread.CurrentThread;
			mainThread.Name = "Main Thread";

			var s1 = Stopwatch.StartNew();
			Thread[] threads = new Thread[numthreads];

			for (int i = 0; i < numthreads; i++) {
				threads[i] = new Thread(new ThreadStart(() => CountUp(target, step, start)));
				threads[i].Name = Convert.ToString(i);
				threads[i].Start();
			}

			bool working = true;
			while (working) {
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
			Console.WriteLine("All threads finished");
			Console.WriteLine("Cycles: " + cycles.ToString("N0"));
			Console.WriteLine("Matches: " + matches);
			Console.WriteLine("Total time: " + ((double)(s1.Elapsed.TotalMilliseconds / 1000)).ToString("0.000 s"));
			Console.WriteLine((cycles / (s1.Elapsed.TotalMilliseconds / 1000)).ToString("N0") + " cycles per second\n");
			goto begin;
		}
		public static void CountUp(int iTarget, int iStep, int iStart)
		{
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
				matches += tmatches;
			}
			finally { Monitor.Exit(tlock); }

			Console.WriteLine("Thread [" + Thread.CurrentThread.Name + "] " + tcycles.ToString("N0") + " cycles");
			return;
		}
	}
}
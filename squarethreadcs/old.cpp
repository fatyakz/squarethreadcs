#include <iostream>
#include <ctime>
// DPC++ fastest
int main()
{
    long long runs = 5;
    long long completed = 0;
    long long start = 1;
    long long target = 9;
    long long step = 1;
    //std::cout << "Target: ";
    //std::cin >> target;
    //if (target == 0) { return 0; }
    target++;

begin:

    long long a = start;
    long long b = start;
    long long c = start;
    long long d = start;
    long long e = start;
    long long f = start;
    long long g = start;
    long long h = start;
    long long i = start;
    //long long cycles = 0;
    long long matches = 0;
    long long finishTime = 0;
    double thistime = 0;
    //long long cps = 0;

    //std::cout << "Step: ";
    //std::cin >> step;
    long long startTime = clock();
sloop:
    if (a == b) { goto notequal; }

    if (a * a + b * b + c * c != d * d + e * e + f * f) { goto notequal; }
    if (a * a + b * b + c * c != g * g + h * h + i * i) { goto notequal; }
    if (a * a + b * b + c * c != a * a + d * d + g * g) { goto notequal; }
    if (a * a + b * b + c * c != b * b + e * e + h * h) { goto notequal; }
    if (a * a + b * b + c * c != c * c + f * f + i * i) { goto notequal; }
    if (a * a + b * b + c * c != a * a + e * e + i * i) { goto notequal; }
    if (a * a + b * b + c * c != c * c + e * e + g * g) { goto notequal; }

testforuniquecells:
    // compare (a) with cells
    if (a == b) { goto notequal; }

    if (a == c) { goto notequal; }

    if (a == d) { goto notequal; }

    if (a == e) { goto notequal; }
    std::cout << "a != e\n";
    if (a == f) { goto notequal; }
    std::cout << "a != f\n";
    if (a == g) { goto notequal; }
    std::cout << "a != g\n";
    if (a == h) { goto notequal; }
    std::cout << "a != h\n";
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
    // count matches
    matches++;
notequal:
    a += 1;
    if (a != target) { goto sloop; }
    a = start;

    b += 1;
    if (b != target) { goto sloop; }
    b = start;

    c += 1;
    if (c != target) { goto sloop; }
    c = start;

    d += step;
    if (d != target) { goto sloop; }
    d = start;

    e += step;
    if (e != target) { goto sloop; }
    e = start;

    f += step;
    if (f != target) { goto sloop; }
    f = start;

    g += step;
    if (g != target) { goto sloop; }
    g = start;

    h += step;
    if (h != target) { goto sloop; }
    h = start;

    i += step;
    if (i != target) { goto sloop; }

    finishTime = clock();
    thistime = (finishTime - startTime) / (double)CLOCKS_PER_SEC;
    //cps = cycles / thistime;
    std::cout << "Matches: " << matches << "\n";
    //std::cout << "Cycles: " << cycles << "\n";
    //std::cout << "Cycles p/s: " << (long)cps << "\n";
    std::cout << "Time: " << thistime << "s\n\n";
    completed++;
    if (completed == runs) { return 0; }
    goto begin;
}

#ifndef MYCONFIG_H_INCLUDED
#define MYCONFIG_H_INCLUDED
#include <windows.h>
#include <conio.h>

#define INTENSE   FOREGROUND_INTENSITY
#define DKBLUE    FOREGROUND_BLUE
#define DKGREEN   FOREGROUND_GREEN
#define DKRED     FOREGROUND_RED
#define DKYELLOW  (RED|GREEN)
#define DKCYAN    (GREEN|BLUE)
#define DKMAGENTA (RED|BLUE)
#define BLUE      (FOREGROUND_BLUE|INTENSE)
#define GREEN     (FOREGROUND_GREEN|INTENSE)
#define RED       (FOREGROUND_RED|INTENSE)
#define YELLOW    (RED|GREEN|INTENSE)
#define CYAN      (GREEN|BLUE|INTENSE)
#define MAGENTA   (RED|BLUE|INTENSE)
#define BLACK     0
#define DKGRAY    INTENSE
#define LTGRAY    (RED|GREEN|BLUE)
#define WHITE     ( RED|GREEN|BLUE|INTENSE)

HANDLE g_consOut;

void clrscr() {
    COORD topLeft = {0, 0};
    DWORD cCharsWritten;
    CONSOLE_SCREEN_BUFFER_INFO csbi;
    GetConsoleScreenBufferInfo(g_consOut, &csbi);
    DWORD dwConSize = csbi.dwSize.X * csbi.dwSize.Y;
    FillConsoleOutputCharacter(g_consOut, ' ', dwConSize,
            topLeft, &cCharsWritten);
    FillConsoleOutputAttribute(g_consOut, csbi.wAttributes,
            dwConSize, topLeft, &cCharsWritten);
    SetConsoleCursorPosition(g_consOut, topLeft);
}

int gettextattr() {
    CONSOLE_SCREEN_BUFFER_INFO buf;
    GetConsoleScreenBufferInfo(g_consOut, &buf);
    return buf.wAttributes;
}

void settextattr(int x) {
    SetConsoleTextAttribute(g_consOut, (WORD)x);
}

void textcolor(int color) {
    SetConsoleTextAttribute(g_consOut, (gettextattr() & 0xf0) | color);
}

void textbackground(int color) {
    SetConsoleTextAttribute(g_consOut, (gettextattr() & 0x0f) | (color << 4));
}

void gotoxy(short col, short row)
{

COORD position={col,row};
SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE),position);
}

void myconfig (void)
{
   g_consOut = GetStdHandle(STD_OUTPUT_HANDLE);
   WORD originalColors = gettextattr();
   settextattr(originalColors);
}
//int main() {
//    g_consOut = GetStdHandle(STD_OUTPUT_HANDLE);
//    WORD originalColors = gettextattr();
//
//    clrscr();
//    textbackground(DKBLUE);
//    textcolor(YELLOW);
//    _cprintf(" Hello");
//    textbackground(DKGREEN);
//    textcolor(CYAN);
//    _cprintf(" World! \n");
//
//
//    settextattr(originalColors);
//    return 0;
//}

//int main() {
//    myconfig();
//    clrscr();
//    textbackground(DKBLUE);
//    textcolor(YELLOW);
//    _cprintf(" Hello");
//    textbackground(DKGREEN);
//    textcolor(CYAN);
//    _cprintf(" World! \n");
//
//

//    return 0;
//}

#endif // MYCONFIG_H_INCLUDED

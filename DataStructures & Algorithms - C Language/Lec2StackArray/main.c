#include <stdio.h>
#include <stdlib.h>
int  tos;
int ar[10];
int push (int d);
int pull (void);
int main()
{
    printf("Hello world!\n");
    return 0;
}
int push (int d)
{
    int retval = 0;
    if (tos < 10)
    {
        ar[tos] = d;
        tos ++;
        retval = 1;
    }
    return retval;
}
int pull (void)
{
    int retval = -1;
    if (tos > 0)
    {
        tos--;
        retval = ar[tos];
    }
    return retval;
}

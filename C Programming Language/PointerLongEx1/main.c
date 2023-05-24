#include <stdio.h>
#include <stdlib.h>

int main()
{
    long multiple [10] = {10L,15L,25L,40L,5L,10L,15L,25L,40L,5L};
    long* p = multiple;
    int i;

    for (i=0;i<sizeof(multiple) / sizeof(multiple[0]);i++)
    {
        printf("adress p+%d (&multiple[%d]): %p         *(p+%d)   value:%ld \n",
                          i,            i,  (p+i),           i,         *(p+i)
        );
    }
    printf("Size of long datatype = %d Byte \n",(int)sizeof(long));
    return 0;
}

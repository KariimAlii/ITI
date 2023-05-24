#include <stdio.h>
#include <stdlib.h>

struct Node
{
    int Data;
    struct Node *pPrev;
    struct Node *pNext;
};
struct Node *pHead;
struct Node *pTail;

int main()
{
    printf("Hello world!\n");
    return 0;
}
void BubbleSort(struct Node *pHead)
{
    int isSwapped, i;

    struct Node *ptr , *lastPtr;
    if (pHead) // There is a list
    {
        do
        {
            isSwapped = 0;
            ptr = pHead;
            while (ptr->pNext != lastPtr || ptr->pNext != NULL)
            {
                if (ptr->Data > ptr->pNext->Data)
                {
                    Swap(ptr, ptr->pNext);
                    isSwapped = 1;
                }
                ptr = ptr->pNext;
            }
            lastPtr = ptr;
        } while (isSwapped = 1)
    }
}
void Swap(struct Node *a, struct Node *b)
{ // call by address
    int Temp;
    Temp = a->Data;
    a->Data = b->Data;
    b->Data = Temp;
}

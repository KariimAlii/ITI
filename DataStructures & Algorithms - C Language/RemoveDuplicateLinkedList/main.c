#include <stdio.h>
#include <stdlib.h>
struct Node
{
    int Data;
    struct Node *pNext;
};

int main()
{
    printf("Hello world!\n");
    return 0;
}

struct Node* RemoveDuplicate(struct Node *pHead)
{
    if (pHead)
    {
        struct Node *ptr = pHead;
        while (ptr->pNext != NULL)
        {
            if (ptr->Data == ptr->pNext->Data)
            {
                ptr->pNext = ptr->pNext->pNext;
            }
            ptr = ptr->pNext;
        }
    }
    return pHead;
}

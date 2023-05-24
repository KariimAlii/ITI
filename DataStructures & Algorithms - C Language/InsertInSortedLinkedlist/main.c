#include <stdio.h>
#include <stdlib.h>

// Given a linked list which is sorted, how will you insert in sorted way
//===========================================================================
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
struct Node* CreateNode(int d)
{
    struct Node *ptr = NULL;
    ptr = (struct Node *)malloc(sizeof(struct Node));
    if (ptr)
    {
        ptr->Data = d;
        ptr->pNext = NULL;
    }
    return ptr;
}
void InsertNodeSorted(struct Node *pHead,int d)
{
    struct Node *pNode = CreateNode(d);
    struct Node *ptr;
    if (pHead == NULL)
    { // there is no List
        pHead = pNode;
    }
    else if (pHead -> Data > d) // The First Node contains data > d
    {
        pNode -> pNext = pHead;
        pHead = pNode;
    }
    else
    {
        ptr = pHead;
        while (ptr->pNext->Data <= pNode->Data && ptr -> pNext != NULL)
        {
            ptr = ptr->pNext;
        }
        // Now ptr points to the last Node having ( Data < d )
        pNode->pNext = ptr -> pNext; // Step 1
        ptr->pNext = pNode; // Step 2
    }
}

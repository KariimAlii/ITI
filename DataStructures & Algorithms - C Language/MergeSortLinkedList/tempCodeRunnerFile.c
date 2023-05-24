#include <stdio.h>
#include <stdlib.h>

struct Node
{
    int Data;
    struct Node *pNext;
};
struct Node *A = NULL;
struct Node *B = NULL;
struct Node *S = NULL;
struct Node *CreateNode(int d)
{
    struct Node *ptr;
    ptr = (struct Node *)malloc(sizeof(struct Node));
    if (ptr)
    {
        ptr->Data = d;
        ptr->pNext = NULL;
    }
    return ptr;
}
struct Node *PushNode(struct Node *pHead, int d)
{
    struct Node *pNode;
    pNode = CreateNode(d);
    if (pHead == NULL)
    {
        pHead = pNode;
    }
    else
    {
        pNode->pNext = pHead;
        pHead = pNode;
    }
    return pHead;
}
void ListNodes(struct Node *pHead)
{
    struct Node *ptr;
    ptr = pHead;
    while (ptr)
    {
        printf("%d --> ", ptr->Data);
        ptr = ptr->pNext;
    }
}
struct Node *Merge(struct Node *a, struct Node *b)
{
    struct Node *s, *Pa, *Pb, *pCur;
    Pa = a;
    Pb = b;
    if (Pa == NULL)
        return Pb;
    if (Pb == NULL)
        return Pa;
    if (Pa->Data < Pb->Data)
    {
        s = pCur = Pa;
        Pa = Pa->pNext;
    }
    else
    {
        s = pCur = Pb;
        Pb = Pb->pNext;
    }

    while (Pa != NULL && Pb != NULL)
    {
        if (Pa->Data < Pb->Data)
        {
            pCur->pNext = Pa;
            pCur = pCur->pNext;
            Pa = Pa->pNext;
        }
        else
        {
            pCur->pNext = Pb;
            pCur = pCur->pNext;
            Pb = Pb->pNext;
        }
    }
    if (Pa == NULL)
        pCur->pNext = Pb;
    else
        pCur->pNext = Pa;
    return s;
}
struct Node *MidPoint(struct Node *Head)
{
    struct Node *Slow = Head;
    struct Node *Fast = Head->pNext;
    while (Fast != NULL && Fast->pNext != NULL)
    {
        Slow = Slow->pNext;        // moves one step
        Fast = Fast->pNext->pNext; // moves two steps
    }
    return Slow;
}
struct Node *MergeSort(struct Node *Head)
{
    //====================== I. Base Case ======================//
    if (Head == NULL || Head->pNext == NULL)
    {
        return Head;
    }
    //====================== II. Recursive Case ======================//
    // Break At The Mid
    struct Node *Mid = MidPoint(Head);
    // Split into Two Halves
    struct Node *a = Head;
    struct Node *b = Mid->pNext;
    Mid->pNext = NULL;
    a = MergeSort(a);
    b = MergeSort(b);

    return Merge(a, b);
}
int main()
{

    A = PushNode(A, 6);
    A = PushNode(A, 9);
    A = PushNode(A, 7);
    A = PushNode(A, 14);
    A = PushNode(A, 17);
    A = PushNode(A, 18);
    A = PushNode(A, 20);
    A = PushNode(A, 8);
    printf("Items of List A : \n");
    ListNodes(A);

    S = MergeSort(A);
    printf("\nItems of Sorted List S : \n");
    ListNodes(S);

    return 0;
}
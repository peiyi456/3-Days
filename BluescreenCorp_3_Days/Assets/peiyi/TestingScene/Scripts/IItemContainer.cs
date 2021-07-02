public interface IItemContainer
{
    //bool ContainsItem(Item item, int count);
    int ItemCount(Item item);
    bool RemoveItem(Item item, int count);
    bool AddItem(Item item, int count);
    bool IsFull();
}

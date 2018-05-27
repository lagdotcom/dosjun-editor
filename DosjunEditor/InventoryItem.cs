using System.IO;

namespace DosjunEditor
{
    public class InventoryItem : IBinaryData
    {
        public const int Size = 5;

        public void Read(BinaryReader br)
        {
            ItemId = br.ReadUInt16();
            Flags = (InventoryFlags)br.ReadByte();
            Quantity = br.ReadByte();
            Slot = (ItemSlot)br.ReadByte();
        }

        public void Write(BinaryWriter bw)
        {
            bw.Write(ItemId);
            bw.Write((byte)Flags);
            bw.Write(Quantity);
            bw.Write((byte)Slot);
        }

        public ushort ItemId { get; set; }
        public InventoryFlags Flags { get; set; }
        public byte Quantity { get; set; }
        public ItemSlot Slot { get; set; }
    }
}

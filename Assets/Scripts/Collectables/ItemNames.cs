public static class ItemNames
{
    public static string Obtener(ItemID id)
    {
        switch (id)
        {
            case ItemID.paper: return "papel";
            case ItemID.paintObject: return "objeto del cuadro";
            case ItemID.vase: return "florero";
            case ItemID.broom: return "escoba";
            case ItemID.lintern: return "linterna";
            case ItemID.archiveKey: return "llave del archivo";
            case ItemID.bossKey: return "llave del jefe";
            case ItemID.breakKey: return "llave de la sala de descanso";
            case ItemID.clockKey: return "llave del reloj";
            case ItemID.conferenceKey: return "llave de la sala de conferencias";
            case ItemID.archiversBook: return "libro de archivos";
            case ItemID.meetingsBook: return "libro de reuniones";
            case ItemID.bathroomBook: return "libro de baños";
            case ItemID.breakroomBook: return "libro de descanso";
            case ItemID.computersBook: return "libro de compus";
            default: return id.ToString();
        }
    }
}
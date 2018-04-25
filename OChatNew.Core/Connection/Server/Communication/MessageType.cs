namespace OChatNew.Core.Connection.Server.Communication
{
    public enum MessageType
    {
        USERWENTONLINE, //"USERWENTONLINE:Oscar"
        USERWENTOFFLINE, //"USERWENTOFFLINE:Oscar"
        ONLINEUSERS, //"ONLINEUSERS:Oscar|Max|Peter|Hans|Simon"
        CONTENTMSG, //"CONTENTMSG:Oscar:Hallo ich heiße oscar rosner"
        CHECKNAME //"CHECKNAME:Oscar          => "CHECKNAME:True"
    }
}
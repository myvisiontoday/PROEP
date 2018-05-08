namespace IManage.Core.Models
{
    /// <summary>
    /// Enum which represents the message for end users
    /// </summary>
    public enum Message
    {
        /// <summary>
        /// When information is saved
        /// </summary>
        Saved = 0,
        /// <summary>
        /// When information is unsaved
        /// </summary>
        UnSaved = 1,
        /// <summary>
        /// When information is updated
        /// </summary>
        Updated = 2,
        /// <summary>
        /// When information is update unsuccess
        /// </summary>
        UpdateUnsucess = 3,
        /// <summary>
        /// When information is delete
        /// </summary>
        Deleted = 3,
        /// <summary>
        /// When information is delete unsuccess
        /// </summary>
        DeleteUnsucess = 4,
        /// <summary>
        /// When input fields are incomplete
        /// </summary>
        NotAllFieldsComplete = 5,

        StartHourAndEndHourCannotBeSame = 6,

        InvalidDate = 7,
        StartHourCannotBeGreater = 8,
        Added = 9,
        UnableToAdd = 10,
        ClockedIn = 11,
        ClockedOut = 12,
        FieldCannotBeEmpty = 13,
        ErrorTryAgain = 14,
        NotificationSent = 15,
        UnableToSendNotification = 16,
        LoggedIn = 17,
        LoggInError = 18,
        NotEnoughCerendital = 19,
        ItemAdded = 20,
        UnableToAddedItem = 21,
        ItemUpdated = 22,
        UnableToUpdateItem = 23,
        ItemDeleted = 24,
        UnableToDeleteItem = 25
    }
}

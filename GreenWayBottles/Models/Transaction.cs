﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace GreenWayBottles.Models
{
    public partial class Transaction : ObservableObject
    {
        [ObservableProperty]
        string transactionType;

        // LocalDate to store the Local computer Date and Time
        [ObservableProperty]
        DateTime localDate;

        [ObservableProperty]
        int bottleId;

        [ObservableProperty]
        int bankDetailsId;

        [ObservableProperty]
        Image signature;
    }
}

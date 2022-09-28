
// metodo sincrono sul thread attuale
//void StampaEdAspetta(int numero)
//{
//    Console.WriteLine($"Avviato {numero}");
//
//    Thread.Sleep(5000);
//
//    Console.WriteLine($"Concluso {numero}");
//}

//StampaEdAspetta(1);
//StampaEdAspetta(2);
//StampaEdAspetta(3);



// metodo asincrono su un nuovo task (non blocca il thread attuale)
async Task StampaEdAspettaAsync(int numero)
{
    Console.WriteLine($"Avviato {numero}");

    await Task.Delay(5000);

    Console.WriteLine($"Concluso {numero}");
}

// avvia 3 task senza aspettarne la conclusione
//StampaEdAspettaAsync(1);
//StampaEdAspettaAsync(2);
//StampaEdAspettaAsync(3);

// avvia 3 task aspettandoli individualmente
await StampaEdAspettaAsync(1);
await StampaEdAspettaAsync(2);
await StampaEdAspettaAsync(3);

// avvia 3 task in parallelo, e poi aspetta che finiscano tutti
//Task task1 = StampaEdAspettaAsync(1);
//Task task2 = StampaEdAspettaAsync(2);
//Task task3 = StampaEdAspettaAsync(3);
//await task1;
//await task2;
//await task3;

// avvia 3 task senza aspettare la conclusione (facendo contento il compilatore)
//_ = StampaEdAspettaAsync(1);
//_ = StampaEdAspettaAsync(2);
//_ = StampaEdAspettaAsync(3);

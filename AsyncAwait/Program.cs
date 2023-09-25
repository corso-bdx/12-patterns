#pragma warning disable CS8321 // Local function is declared but never used

// metodo sincrono sul thread attuale
void StampaEdAspetta(int numero)
{
    Console.WriteLine($"Avviato {numero}");

    Thread.Sleep(5000);

    Console.WriteLine($"Concluso {numero}");
}

// metodo asincrono su un nuovo task (non blocca il thread attuale)
async Task StampaEdAspettaAsync(int numero)
{
    Console.WriteLine($"Avviato {numero}");

    await Task.Delay(5000);

    Console.WriteLine($"Concluso {numero}");
}

// metodo sincrono: le tre operazioni sono eseguite sequenzialmente
//StampaEdAspetta(1);
//StampaEdAspetta(2);
//StampaEdAspetta(3);

// metodo asincrono: avvia 3 task senza aspettarne la conclusione
// (warning in quanto lanciare un task senza aspettarlo è solitamente una dimenticanza)
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
// codice alternativo: await Task.WhenAll(task1, task2, task3);

// avvia 3 task senza aspettare la conclusione
// (underscore indica esplicitamente di non aspettare la conclusione, nessun warning)
//_ = StampaEdAspettaAsync(1);
//_ = StampaEdAspettaAsync(2);
//_ = StampaEdAspettaAsync(3);

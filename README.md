# Cinema
Simple online cinema tickets booking.
Cinema consists of three Halls, has three price categories(each category has its own multiplier rate - so price depends on movie base price and seat position in hall)
Cinema has 6 movies for now.
Each movie may be shown on different dates and halls(or the same dates and time - but in different halls)
Timetable of every shown movie is configured in PlayBill database table. In the same table we configure base price of ticket - because price may differ on dates(premiers are more expensive, old films are cheaper)
When user boocked a ticket - it is recorded to Booking table - toghether with user's name and email, it's playBillId(reference to timetable with movies) and seatId(reference to Seats table), and DateCreated(datetime when order was done)

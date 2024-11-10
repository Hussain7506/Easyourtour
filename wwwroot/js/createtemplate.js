
        $(document).ready(function () {
            let optionCount = 0;

            $('#loadSection2').click(function () {
                const days = $('#NumberOfDays').val();
                if (days > 0) {
                    $('#section2').show();
                    initializeItineraryTable(0, days);
                    $('#section3').show();
                    initializeTravelTable(0, days);
                    $('#section4').show();
                }
            });

            $('#addOption').click(function () {
                optionCount++;
                const newOption = duplicateOption(optionCount);
                $('#optionsContainer').append(newOption.hotelTable);
                initializeItineraryTable(optionCount, $('#NumberOfDays').val());
            });

            function initializeItineraryTable(option, days) {
                const tbody = $(`#hotelTable_${option} tbody`);
                tbody.empty();
                for (let i = 1; i <= days; i++) {
                    let row = `<tr data-day="${i}">
                                <td>${i}</td>
                                        <input type="hidden" name="HotelDestinationOptions[${option}].HotelDestinationDays[${i - 1}].DayNumber" value="${i}" />
                                <td>
                                    <select class="form-control destination-dropdown" name="HotelDestinationOptions[${option}].HotelDestinationDays[${i - 1}].DestinationId" data-day="${i}">
                                        <option value="">-- Select Destination --</option>
                                        @foreach (var dest in ViewBag.Destinations)
                                        {
                                            <option value="@dest.Value">@dest.Text</option>
                                        }
                                    </select>
                                </td>
                                <td>
                                    <select class="form-control location-dropdown" name="HotelDestinationOptions[${option}].HotelDestinationDays[${i - 1}].LocationId" data-day="${i}">
                                        <option value="">-- Select Location --</option>
                                    </select>
                                </td>
                                <td>
                                    <select class="form-control hotel-dropdown" name="HotelDestinationOptions[${option}].HotelDestinationDays[${i - 1}].HotelId" data-day="${i}">
                                        <option value="">-- Select Hotel --</option>
                                    </select>
                                </td>
                                <td>
                                    <select class="form-control hotelroom-dropdown" name="HotelDestinationOptions[${option}].HotelDestinationDays[${i - 1}].HotelRoomId" data-day="${i}">
                                        <option value="">-- Select Hotel Room --</option>
                                    </select>
                                </td>
                                <td><input type="text" class="form-control" name="HotelDestinationOptions[${option}].HotelDestinationDays[${i - 1}].Capacity" data-day="${i}" readonly /></td>
                                <td><input type="number" class="form-control" name="HotelDestinationOptions[${option}].HotelDestinationDays[${i - 1}].ExtraBeds" placeholder="Number of Extra Beds" value="0" /></td>
                                <td><input type="text" class="form-control" name="HotelDestinationOptions[${option}].HotelDestinationDays[${i - 1}].Inclusions" data-day="${i}" readonly /></td>
                                <td><input type="number" class="form-control" name="HotelDestinationOptions[${option}].HotelDestinationDays[${i - 1}].NumRooms" value="1" /></td>
                            </tr>`;
                    tbody.append(row);
                }
                attachDropdownHandlers(option);
            }

            function initializeTravelTable(option, days) {
                const tbody = $(`#travelTable_${option} tbody`);
                tbody.empty();
                for (let i = 1; i <= days; i++) {
                    let row = `<tr data-day="${i}">
                                <td>${i}</td>
                                <input type="hidden" name="TravelSightseeingOptions[${option}].TravelSightseeingDays[${i - 1}].DayNumber" value="${i}" />
                                <td>
                                    <select class="form-control transport-dropdown" name="TravelSightseeingOptions[${option}].TravelSightseeingDays[${i - 1}].CarTypeId" data-day="${i}">
                                        <option value="">-- Select Car Type --</option>
                                    </select>
                                </td>
                                <td><input type="number" class="form-control kilometers-input" name="TravelSightseeingOptions[${option}].TravelSightseeingDays[${i - 1}].Kilometers" /></td>
                                <td>
                                    <select class="form-control sightseeing-dropdown" name="TravelSightseeingOptions[${option}].TravelSightseeingDays[${i - 1}].SightseeingSpotIds" data-day="${i}" multiple>
                                    </select>
                                </td>
                                <td><input type="text" class="form-control miscellaneous-input" name="TravelSightseeingOptions[${option}].TravelSightseeingDays[${i - 1}].Miscellaneous" /></td>
                                <td><input type="text" class="form-control base-price" name="TravelSightseeingOptions[${option}].TravelSightseeingDays[${i - 1}].BasePrice" data-day="${i}" readonly /></td>
                                <td><input type="text" class="form-control base-distance" name="TravelSightseeingOptions[${option}].TravelSightseeingDays[${i - 1}].BaseDistance" data-day="${i}" readonly /></td>
                            </tr>`;
                    tbody.append(row);
                }
                attachDropdownHandlers(option);
            }

            function attachDropdownHandlers(option) {
                $(`select[name^="HotelDestinationOptions[${option}].HotelDestinationDays"]`).change(function () {
                    const day = $(this).closest('tr').data('day');
                    const name = $(this).attr('name');
                    if (name.includes('DestinationId')) {
                        const destinationId = $(this).val();
                        if (destinationId) {
                            loadLocations(destinationId, day, option);
                            loadSightseeings(destinationId, day);
                        }
                    } else if (name.includes('LocationId')) {
                        const locationId = $(this).val();
                        if (locationId) {
                            loadTransportDetails(locationId, day);
                            loadHotels(locationId, day, option);
                            
                        }
                    } else if (name.includes('HotelId')) {
                        const hotelId = $(this).val();
                        if (hotelId) {
                            loadHotelRooms(hotelId, day, option);
                        }
                    }
                });
            }

            function loadLocations(destinationId, day, option) {
                const locationDropdown = $(`select[name="HotelDestinationOptions[${option}].HotelDestinationDays[${day - 1}].LocationId"]`);
                $.ajax({
                    url: '/TripPlanner/GetLocations/' + destinationId,
                    type: 'GET',
                    success: function (data) {
                        locationDropdown.empty().append('<option value="">-- Select Location --</option>');
                        $.each(data, function (i, location) {
                            locationDropdown.append('<option value="' + location.id + '">' + location.name + '</option>');
                        });
                    },
                    error: function (xhr, status, error) {
                        console.error("Error fetching locations:", error);
                    }
                });
            }
            function duplicateOption(optionCount) {
    // Create a new hotel table
    const newHotelTable = $('<table id="hotelTable_' + optionCount + '" class="table table-bordered"></table>');
    const tbody = $('<tbody></tbody>');
    newHotelTable.append(tbody);

    // Create the table header
    const thead = $('<thead></thead>');
    newHotelTable.append(thead);
    const headerRow = $('<tr></tr>');
    thead.append(headerRow);
    headerRow.append('<th>Day</th>');
    headerRow.append('<th>Destination</th>');
    headerRow.append('<th>Location</th>');
    headerRow.append('<th>Hotel</th>');
    headerRow.append('<th>Hotel Room</th>');
    headerRow.append('<th>Capacity</th>');
    headerRow.append('<th>No. of Extra Beds</th>');
    headerRow.append('<th>Inclusions</th>');
    headerRow.append('<th>No. of Rooms</th>');

    const days = $('#NumberOfDays').val();
    for (let i = 1; i <= days; i++) {
        let row = $('<tr data-day="' + i + '"></tr>');
        tbody.append(row);
        row.append('<td>' + i + '</td>');
        row.append('<td><select class="form-control destination-dropdown" name="HotelDestinationOptions[' + optionCount + '].HotelDestinationDays[' + (i - 1) + '].DestinationId" data-day="' + i + '"><option value="">-- Select Destination --</option>@foreach (var dest in ViewBag.Destinations) {<option value="@dest.Value">@dest.Text</option>}</select></td>');
        row.append('<td><select class="form-control location-dropdown" name="HotelDestinationOptions[' + optionCount + '].HotelDestinationDays[' + (i - 1) + '].LocationId" data-day="' + i + '"><option value="">-- Select Location --</option></select></td>');
        row.append('<td><select class="form-control hotel-dropdown" name="HotelDestinationOptions[' + optionCount + '].HotelDestinationDays[' + (i - 1) + '].HotelId" data-day="' + i + '"><option value="">-- Select Hotel --</option></select></td>');
        row.append('<td><select class="form-control hotelroom-dropdown" name="HotelDestinationOptions[' + optionCount + '].HotelDestinationDays[' + (i - 1) + '].HotelRoomId" data-day="' + i + '"><option value="">-- Select Hotel Room --</option></select></td>');
        row.append('<td><input type="text" class="form-control capacity" name="HotelDestinationOptions[' + optionCount + '].HotelDestinationDays[' + (i - 1) + '].Capacity" data-day="' + i + '" readonly /></td>');
        row.append('<td><input type="number" class="form-control extra-beds" name="HotelDestinationOptions[' + optionCount + '].HotelDestinationDays[' + (i - 1) + '].ExtraBeds" placeholder="Number of Extra Beds" /></td>');
        row.append('<td><input type="text" class="form-control inclusions" name="HotelDestinationOptions[' + optionCount + '].HotelDestinationDays[' + (i - 1) + '].Inclusions" data-day="' + i + '" readonly /></td>');
        row.append('<td><input type="number" class="form-control num-rooms" name="HotelDestinationOptions[' + optionCount + '].HotelDestinationDays[' + (i - 1) + '].NumRooms" /></td>');
    }

    const newOption = $('<div class="option-group" data-option="' + optionCount + '"></div>');
    newOption.append('<h4>Option ' + (optionCount + 1) + '</h4>');
    newOption.append(newHotelTable);
    $('#optionsContainer').append(newOption);
    initializeItineraryTable(optionCount, days);
}



            function loadHotels(locationId, day, option) {
                const hotelDropdown = $(`select[name="HotelDestinationOptions[${option}].HotelDestinationDays[${day - 1}].HotelId"]`);
                const starRatings = $('#StarRating').val();
                if (typeof starRatings === 'string') {
                    starRatings = starRatings.split(',').map(Number);
                }
                console.log("The Star Ratings are" + starRatings);
                $.ajax({
                    url: '/TripPlanner/GetHotels',
                    type: 'GET',
                    traditional: true,  // This will ensure the array is passed correctly
                    data: {
                        locationId: locationId,
                        starRatings: starRatings
                    },
                    success: function (data) {
                        hotelDropdown.empty().append('<option value="">-- Select Hotel --</option>');
                        $.each(data, function (i, hotel) {
                            hotelDropdown.append('<option value="' + hotel.id + '">' + hotel.name + '</option>');
                        });
                    },
                    error: function (xhr, status, error) {
                        console.error("Error fetching hotels:", error);
                    }
                });
            }

            function loadHotelRooms(hotelId, day, option) {
                const hotelRoomDropdown = $(`select[name="HotelDestinationOptions[${option}].HotelDestinationDays[${day - 1}].HotelRoomId"]`);

                $.ajax({
                    url: '/TripPlanner/GetHotelRooms',
                    type: 'GET',
                    data: { hotelId: hotelId },
                    success: function (data) {
                        hotelRoomDropdown.empty().append('<option value="">-- Select Hotel Room --</option>');
                        $.each(data, function (i, room) {
                            hotelRoomDropdown.append(`<option value="${room.id}" data-capacity="${room.capacity}" data-extracharge="${room.extraChargePerPerson}" data-inclusions="${room.inclusions}">${room.roomType}</option>`);
                        });
                    },
                    error: function (xhr, status, error) {
                        console.error("Error fetching hotel rooms:", error);
                    }
                });

                hotelRoomDropdown.change(function () {
                    const selectedOption = $(this).find('option:selected');
                    const capacity = selectedOption.data('capacity');
                    const inclusions = selectedOption.data('inclusions');
                    const extraChargePerPerson = selectedOption.data('extracharge');

                    $(`input[name="HotelDestinationOptions[${option}].HotelDestinationDays[${day - 1}].Capacity"]`).val(capacity);
                    $(`input[name="HotelDestinationOptions[${option}].HotelDestinationDays[${day - 1}].Inclusions"]`).val(inclusions);
                });
            }

            function loadTransportDetails(locationId, day, option) {
                const transportDropdown = $(`.transport-dropdown[data-day="${day}"]`);

                $.ajax({
                    url: `/TripPlanner/GetTransports/${locationId}`,
                    type: 'GET',
                    success: function (data) {
                        transportDropdown.empty().append('<option value="">-- Select car type --</option>');
                        $.each(data, function (i, transport) {
                            transportDropdown.append(`<option value="${transport.id}" data-basePrice="${transport.basePrice}" data-baseDistance="${transport.baseDistance}" data-pricePerKm="${transport.pricePerKm}">${transport.carType}</option>`);
                        });
                    },
                    error: function (xhr, status, error) {
                        console.error("Error fetching transport details:", error);
                    }
                });

                transportDropdown.change(function () {
                    const selectedOption = $(this).find('option:selected');
                    const basePrice = selectedOption.data('baseprice');
                    const baseDistance = selectedOption.data('basedistance');

                    $(`input.base-price[data-day="${day}"]`).val(basePrice);
                    $(`input.base-distance[data-day="${day}"]`).val(baseDistance);
                });
            }

            function loadSightseeings(destinationId, day, option) {
                const sightseeingDropdown = $(`.sightseeing-dropdown[data-day="${day}"]`);

                $.ajax({
                    url: `/TripPlanner/GetSightseeings/${destinationId}`,
                    type: 'GET',
                    success: function (data) {
                        sightseeingDropdown.empty();
                        $.each(data, function (i, sight) {
                            sightseeingDropdown.append(`<option value="${sight.id}">${sight.name}</option>`);
                        });
                    },
                    error: function (xhr, status, error) {
                        console.error("Error fetching sightseeing spots:", error);
                    }
                });
            }
        });
import { useEffect, useState } from "react";
import BookingsReadForm from "../entites/form_read_booking";
interface BookingsDto
{
	id: number;
	dateArrived: string;
	dateDeparture: string;
	numberRoom: number;
	name: string;
	surname: string;
	status: string;
}
function parseBookingsDto(source: string): BookingsDto[]
{
	const parsed = JSON.parse(source);
	return parsed.map((item: unknown)=>{
		if (
			typeof item === 'object' &&
			item !== null &&
			'id' in item &&
			'dateArrived' in item &&
			'dateDeparture' in item &&
			'numberRoom' in item &&
			'name' in item &&
			'surname' in item &&
			'status' in item
		)
		{
			const booking = item as{
				id: unknown;
				dateArrived: unknown;
				dateDeparture: unknown;
				numberRoom: unknown;
				name: unknown;
				surname: unknown;
				status: unknown;
			};
			if (
				typeof booking.id === 'number' &&
				typeof booking.dateDeparture === 'string' &&
				typeof booking.dateArrived === 'string' &&
				typeof booking.name === 'string' &&
				typeof booking.surname === 'string' &&
				typeof booking.numberRoom === 'number' &&
				typeof booking.status === 'string'
			){
				return {
					id: booking.id,
					dateArrived: booking.dateArrived,
					dateDeparture: booking.dateDeparture,
					numberRoom: booking.numberRoom,
					name: booking.name,
					surname: booking.surname,
					status: booking.status
				};
			}
		}});
}
const BookingsList = ()=>
{
	const [data, setData] = useState<BookingsDto[]>([]);
	useEffect(()=>{
		const fetchData = async()=>{
			const response = await fetch('http://localhost:5000/api/bookings',{
				method:'GET',
				headers:{'Content-Type':'application/json'}
			}
		);
		const result = await response.text();
		const read_data : BookingsDto[] = parseBookingsDto(result);
		setData(read_data);
		};
		fetchData();
	},[]);
	if (data.length !== 0)
	{
		data.sort((a,b)=>a.id - b.id);
		return (<div>
			{data.map((booking)=>(<>
				<BookingsReadForm
					bId={booking.id.toString() + '(id)'}
					bDateArrived={booking.dateArrived.replace('T', ' ').replaceAll('-', '.')}
					bDateDeparture={booking.dateDeparture.replaceAll('-', '.').replace('T', ' ')}
					bNumberRoom={booking.numberRoom.toString() + '(Room)'}
					bName={booking.name}
					bSurname={booking.surname}
					bStatus={booking.status}
				/>
				<p></p></>))}
			</div>);
	}
	else return <></>;
}
export default BookingsList;

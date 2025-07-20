import { useEffect } from 'react';
interface AddBookingProps
{
	name: string;
	surname: string;
	dateArrived: string;
	dateDeparture: string;
	number: string;
	onConfirm : (confirm: number)=>void;
}
const AddBooking = ({name, surname, dateArrived, dateDeparture, number,onConfirm}:AddBookingProps) =>
{
	const parse_date = (input: string)=>
	{
		let data: string[] = input.split('.');
		return data[2]+'-'+data[1]+'-'+data[0]+'T00:00:00+03:00';
	}
	const date_regex: RegExp = /^\d{2}\.\d{2}\.\d{4}$/;
	if (!(date_regex.test(dateArrived)&&date_regex.test(dateDeparture)))
		return (<></>);
	else
	{
		let date_arrived: string = parse_date(dateArrived);
		let date_departure: string = parse_date(dateDeparture);
		useEffect(()=>
		{
			const fetchData = async ()=>
			{
				await fetch('http://localhost:5000/api/bookings',
					{
						method:'POST',
						headers:{'Content-Type':'application/json'},
						body: JSON.stringify({
							'id':'0',
							'DateArrived':date_arrived,
							'DateDeparture': date_departure,
							'NumberRoom':number,
							'Name': name,
							'Surname':surname
						})
					});
			};
			fetchData();
		},[]);
	}
	onConfirm(33);
	return <></>;
}
export default AddBooking;


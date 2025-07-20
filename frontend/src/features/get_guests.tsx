import { useEffect, useState } from "react";
import GuestForm from "../entites/form_guest";
interface GuestsDto
{
	id: number;
	name: string;
	surname: string;
	phone: string;
	email: string;
}
function parseGuestsDto(source: string):GuestsDto[]
{
	const parsed = JSON.parse(source);
	return parsed.map((item:unknown)=>{
		if (
			typeof item === 'object' &&
			item !== null &&
			'id' in item &&
			'name' in item &&
			'surname' in item &&
			'phone' in item &&
			'email' in item
		)
		{
			const guest = item as {
				id: unknown;
				name: unknown;
				surname: unknown;
				phone: unknown;
				email: unknown;
			};
			if (
				typeof guest.id === 'number' &&
				typeof guest.name === 'string' &&
				typeof guest.surname === 'string' &&
				typeof guest.phone === 'string' &&
				typeof guest.email === 'string'
			){
				return {
					id: guest.id,
					name: guest.name,
					surname: guest.surname,
					phone: guest.phone,
					email: guest.email
				};
			}
		}});
}
const GuestsList = () =>
{
	const [data, setData] = useState<GuestsDto[]>([]);
	useEffect(()=>{
		const fetchData = async()=> {
			const response = await fetch('http://localhost:5000/api/guests', {
				method: 'GET',
				headers: {'Content-Type':'application/json'},
			}
		);
		const result = await response.text();
		const read_data : GuestsDto[] = parseGuestsDto(result);
		setData(read_data);
		};
		fetchData();
	},[]);
	if (data.length !== 0)
	{
		data.sort((a,b)=>a.id-b.id);
		return ( <div className="guest_list">
			{data.map((guest)=>(<>
				<GuestForm
					gId={guest.id}
					gName={guest.name}
					gSurname={guest.surname}
					gPhone={guest.phone}
					gEmail={guest.email}
				/>
				<p></p> </>))}
				</div>);
	}
	else return <></>;
};
export default GuestsList;

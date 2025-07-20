import { useState, useEffect } from "react";
import type { JSX } from "react";
import './free_rooms.css';
function parse_date(input: string): string
{
	try
	{
	let data : string[] = input.split('.');
	let res : string = data[2] + '-'+data[1]+'-'+data[0] + 'T00:00:00+03';
	return res;
	}
	catch(e)
	{
		return '';	
	}
}
interface FreeRoomListProps
{
	date_arrived: string;
	date_departure: string;
	onErrorChange: (hasError: boolean)=>void;
}
interface RoomsDto
{
	id : number;
	number : number;
	type : string;
	costPerNight : number;
	capacity : number;
}
function parseRoomsDto(source : string) : RoomsDto[]
{
	const parsed = JSON.parse(source);
	return parsed.map((item : unknown)=>{
		if (
			typeof item === 'object' &&
			item !== null &&
			"id" in item && 
			"number" in item && 
			"type" in item &&
			"costPerNight" in item &&
			"capacity" in item
		)
		{
			const room = item as {
				id : unknown;
				number : unknown;
				type : unknown;
				costPerNight : unknown;
				capacity : unknown;
			};
			if (
				typeof room.id ==='number' &&
				typeof room.number === 'number' &&
				typeof room.type === 'string' &&
				typeof room.costPerNight === 'number' &&
				typeof room.capacity === 'number'
			){
				return {
					id : room.id,
					number : room.number,
					type : room.type,
					costPerNight : room.costPerNight,
					capacity : room.capacity
				};
			}
	}});
}
const FreeRoomList = ({date_arrived, date_departure, onErrorChange}: FreeRoomListProps) : JSX.Element =>
{
	const [data, setData] = useState<RoomsDto[]>([]);
	const [loading, setLoading] = useState<boolean>(false);
	const [error, setError] = useState<string | null>(null);
	const date_regex : RegExp = /^\d{2}\.\d{2}\.\d{4}$/;
	if (!(date_regex.test(date_arrived) && date_regex.test(date_departure))) {onErrorChange(false);return <></>;}
	let	date_arr_str = parse_date(date_arrived);
	let date_dep_str = parse_date(date_departure);
	useEffect(() => {
			const fetchData = async ()=> {
			setLoading(true);
			try
			{
				const response = await fetch("http://localhost:5000/api/bookings/free_rooms", {
					method:'POST',
					headers: {"Content-type": "application/json"},
					body: JSON.stringify({'DateArrived': date_arr_str,'DateDeparture':date_dep_str}),
					}
				);
				if (!response.ok)
					{
						throw new Error('Error http');
					}
					const result : string  = await response.text();
					const rd : RoomsDto[]= parseRoomsDto(result);
				setData(rd);
			}
			catch (err) {
      	setError(err instanceof Error ? err.message : 'Unknown error');
    	} finally {
      	setLoading(false);
    	}
		};
		fetchData();
	},[date_arrived, date_departure, onErrorChange]);
	if (loading) return <div>Loading...</div>;
	if (error) {onErrorChange(false);return <div> Error : {error}</div>;}
	if (data.length != 0){
		onErrorChange(true);
	return( <div className="room_list" >
		<h2 className="title_list">Список номеров</h2>
      <ul className="no-markers">
        {data.map((room) => (
					<li key={room.id} className="room-item">
            <div className="room-header">
              <span className="room-number">Номер {room.number}</span>
              <span className="room-type"> {room.type}</span>
            </div>
            <div className="room-details">
              <span>Цена: {room.costPerNight}₽ за ночь</span>
              <span>Вместимость: {room.capacity} чел.</span>
            </div>
          </li>
        ))}
      </ul>
				</div>
				);
	}
	else return <></>;
};
export default FreeRoomList;

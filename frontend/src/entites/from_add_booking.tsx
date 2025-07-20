import {type JSX, type CSSProperties, useState} from 'react';
import Edit from '../shared/ui/edit';
import './from_add_booking.css';
import Button from '../shared/ui/button';
import AddBooking from '../features/add_booking';
interface FormAddBookingProps
{
	onClickChange: (click: boolean)=>void;
	onDateArrivedCahnge: (dateArrived:string)=>void;
	onDateDepartureChange:(dateDeparture: string)=>void;
	dateArrived: string;
	dateDeparture: string;
}
const FormAddBooking = ({onClickChange, onDateArrivedCahnge, onDateDepartureChange, dateArrived, dateDeparture} : FormAddBookingProps):JSX.Element=>
{
	const [name, setName] = useState<string>('');
	const [surname, setSurname] = useState<string>('');
	const [number, setNumber] = useState<string>('');
	const [confirm, setConfirm] = useState<number>(0);
	const [close, setClose] = useState<boolean>(false);
	if(close || (confirm === 33)){onClickChange(false);onDateArrivedCahnge('');onDateDepartureChange('');return (<></>)};
	return (
		<>
		<div className='form_add_booking' id='afb' style={
			{width: 400, height: 400}as CSSProperties
			}>
			<Edit
				left={20}
				top={8}
				label={'имя'}
				id={'nm'}
				style={0}
				value={name}
				onChange={setName}
			/>
			<Edit
				left={20}
				top={90}
				label={'фамилия'}
				id={'sn'}
				style={0}
				value={surname}
				onChange={setSurname}
			/>
			<Edit
				left={20}
				top={172}
				label={'номер'}
				id={'num'}
				style={0}
				value={number}
				onChange={setNumber}
			/>
			<Button
				label={'принять'}
				left={290}
				top={300}
				action={()=>{setConfirm(confirm+1);}}
				style={0}
			/>
			<Button
				label={'X'}
				left={290}
				top={8}
				action={()=>{setClose(!close);}}
				style={2}
			/>
			</div>
				{confirm && <AddBooking name={name} surname={surname} dateArrived={dateArrived} dateDeparture={dateDeparture} number={number} onConfirm={setConfirm}/> }
		</>
	);
}
export default FormAddBooking;

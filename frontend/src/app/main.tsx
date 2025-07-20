import ReactDOM from 'react-dom/client';
import App from './App';

const root_element : HTMLElement | null = document.getElementById('root');
document.body.style.backgroundColor = '#000';
if (root_element)
{
	const root : ReactDOM.Root = ReactDOM.createRoot(root_element);
	root.render(<><App /></>);
}
else
{
	console.error('Элемент c id \'root\' не найден!');
}

import './App.css';
import { store } from "./actions/store";
import { Provider } from "react-redux";
import NewsSearch from './components/NewsSearch';

function App() {
  return (
    <Provider store = {store}>
      <NewsSearch />
    </Provider>
  );
}

export default App;

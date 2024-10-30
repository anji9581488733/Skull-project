import sys
import os
import time
import stat
from selenium import webdriver
from selenium.webdriver.chrome.service import Service
from selenium.webdriver.chrome.options import Options
from webdriver_manager.chrome import ChromeDriverManager
import logging

def take_screenshot(driver_version):
    logging.basicConfig(level=logging.INFO)

    try:
        # Setup Chrome options
        chrome_options = Options()
        chrome_options.add_argument("--headless")
        chrome_options.add_argument("--no-sandbox")
        chrome_options.add_argument("--disable-dev-shm-usage")
        chrome_options.add_argument("--disable-gpu")
        chrome_options.add_argument("--window-size=1920x1080")

        chrome_driver_path = ChromeDriverManager(driver_version=driver_version).install()
        if chrome_driver_path:
            chrome_name = chrome_driver_path.split('/')[-1]
            if chrome_name != "chromedriver" and chrome_name != "chromedriver.exe":
                chrome_driver_dir = os.path.dirname(chrome_driver_path)
                chrome_driver_path = os.path.join(chrome_driver_dir, "chromedriver" + (".exe" if os.name == 'nt' else ""))
                os.chmod(chrome_driver_path, stat.S_IRWXU | stat.S_IRGRP | stat.S_IXGRP | stat.S_IROTH | stat.S_IXOTH)
        logging.info(f"Using ChromeDriver at {chrome_driver_path}")

        webdriver_service = Service(chrome_driver_path)
        driver = webdriver.Chrome(service=webdriver_service, options=chrome_options)

        base_path = os.getenv('GITHUB_WORKSPACE', os.path.dirname(os.getcwd()))
        index_path = os.path.join(base_path, 'allure-report', 'index.html')
        driver.get(f'file://{index_path}')
        
        # Wait for 5 seconds
        time.sleep(5)

        screenshot_path = os.path.join(base_path, 'screenshot.png')
        driver.save_screenshot(screenshot_path)
        logging.info("Screenshot taken and saved.")

    except Exception as e:
        logging.error(f"Error taking screenshot: {e}")
        sys.exit(1)

if __name__ == "__main__":
    if len(sys.argv) > 1:
        driver_version_arg = sys.argv[1]
    else:
        logging.error("No driver version argument provided.")
        sys.exit(1)
    
    take_screenshot(driver_version_arg)
